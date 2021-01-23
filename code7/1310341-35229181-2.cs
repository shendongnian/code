    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var result = PlaceNonOverlappingBlocks(1000, 5, 500, 500);
            }
            static List<Block> PlaceNonOverlappingBlocks(int count, int maxBlockSize, int mapX, int mapY)
            {
                var map    = new bool[mapY, mapX];
                var rng    = new Random();
                var result = new List<Block>(count);
                int misses = 0; 
                while (count > 0)
                {
                    int size = rng.Next(1, maxBlockSize + 1);
                    int x = rng.Next(0, mapX - size);
                    int y = rng.Next(0, mapY - size);
                    if (fits(map, x, y, size))
                    {
                        result.Add(new Block(x, y, size));
                        addToMap(map, x, y, size);
                        --count;
                    }
                    else
                    {
                        if (++misses > 100000)
                            throw new InvalidOperationException("Hell has frozen over"); // Keep Joe Blow happy...
                    }
                }
                // This is just for diagnostics, and can be removed.
                Console.WriteLine($"There were {misses} misses.");
                return result;
            }
            static void addToMap(bool[,] map, int px, int py, int size)
            {
                for (int x = px; x < px+size; ++x)
                    for (int y = py; y < py + size; ++y)
                        map[y, x] = true;
            }
            static bool fits(bool[,] map, int px, int py, int size)
            {
                for (int x = px; x < px + size; ++x)
                    for (int y = py; y < py + size; ++y)
                        if (map[y, x])
                            return false;
                return true;
            }
            internal class Block
            {
                public int X    { get; }
                public int Y    { get; }
                public int Size { get; }
                public Block(int x, int y, int size)
                {
                    X = x;
                    Y = y;
                    Size = size;
                }
            }
        }
    }
