using System;

namespace DELETEME
{
    internal class Program
    {
        private static char[,] canvas =
        {
            {'-', '*', '-', '-', '-', '-', '-', '-', '-'},
            {'*', '-', '-', '-', '*', '-', '*', '-', '-'},
            {'-', '*', '-', '-', '*', '*', '*', '-', '*'},
            {'*', '*', '-', '*', '*', '*', '*', '-', '*'}
        };
        
        public static void Main(string[] args)
        {
            Draw();
            Sort();
            Draw();
        }

        private static void Draw()
        {
            for (var x = 0; x < canvas.GetLength(0); x++)
            {
                for (var y = 0; y < canvas.GetLength(1); y++)
                {
                    Console.Write(canvas[x,y] + ", ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("================================");
        }

        private static void Sort()
        {
            var middleIndex = canvas.GetLength(1) / 2;
            for (var x = 0; x < canvas.GetLength(0); x++)
            {
                for (var y = canvas.GetLength(1) - 1; y > 0; y--)
                {
                    if (canvas[x, y] == '-') continue;

                    for (var emptyPos = 0; emptyPos < canvas.GetLength(1); emptyPos++)
                    {
                        if(emptyPos > y) break;
                        if (canvas[x, emptyPos] != '-') continue;
                        
                        Swap(new Vector2(x, y), new Vector2(x, emptyPos));
                        break;
                    }
                }

                var moveDelta = middleIndex - x;
                
                for (var y = canvas.GetLength(1) - 1; y >= 0; y--)
                {
                    if (canvas[x, y] == '-') continue;

                    Swap(new Vector2(x,y), new Vector2(x, y + moveDelta));
                }
            }
        }

        private static void Swap(Vector2 first, Vector2 second)
        {
            (canvas[first.X, first.Y], canvas[second.X, second.Y]) =
                (canvas[second.X, second.Y], canvas[first.X, first.Y]);
        }
        
        private struct Vector2
        {
            public int X;
            public int Y;

            public Vector2(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}