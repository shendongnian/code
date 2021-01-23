        public static void DrawChart(List<Point> dict)
        {
            int consoleWidth = 78;
            int consoleHeight = 20;
            int actualConsoleHeight = consoleHeight * 2;
            var minX = dict.Min(c => c.X);
            var minY = dict.Min(c => c.Y);            
            var maxX = dict.Max(c => c.X);
            var maxY = dict.Max(c => c.Y);
            
            Console.WriteLine(maxX);
            // normalize points to new coordinates
            var normalized = dict.
                Select(c => new Point(c.X - minX, c.Y - minY)).
                Select(c => new Point((int)Math.Round((float) (c.X) / (maxX - minX) * (consoleWidth - 1)), (int)Math.Round((float) (c.Y) / (maxY - minY) * (actualConsoleHeight - 1)))).ToArray();
            Func<int, int, bool> IsHit = (hx, hy) => {
                return normalized.Any(c => c.X == hx && c.Y == hy);
            };
            for (int y = actualConsoleHeight - 1; y > 0; y -= 2)
            {
                Console.Write(y == actualConsoleHeight - 1 ? '┌' : '│');
                for (int x = 0; x < consoleWidth; x++)
                {
                    bool hitTop = IsHit(x, y);
                    bool hitBottom = IsHit(x, y - 1);                    
                    if (hitBottom && hitTop)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write('█');
                    }
                    else if (hitTop)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write('▀');
                    }
                    else if (hitBottom)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write('▀');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write('▀');
                    }                    
                }                
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine('└' + new string('─', (consoleWidth / 2) - 1) + '┴' + new string('─', (consoleWidth / 2) - 1) + '┘');
            Console.Write((dict.Min(x => x.X) + "/" + dict.Min(x => x.Y)).PadRight(consoleWidth / 3));
            Console.Write((dict.Max(x => x.Y) / 2).ToString().PadLeft(consoleWidth / 3 / 2).PadRight(consoleWidth / 3));
            Console.WriteLine(dict.Max(x => x.Y).ToString().PadLeft(consoleWidth / 3));
        }
