    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    
    namespace ConsoleWithImage
    {
        class Program
        {
    
            public static ConsoleColor ToConsoleColor(System.Drawing.Color c)
            {
                int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0;
                index |= (c.R > 64) ? 4 : 0;
                index |= (c.G > 64) ? 2 : 0;
                index |= (c.B > 64) ? 1 : 0;
                return (ConsoleColor)index;
            }
    
    
            static Color[] colorTable = new Color[] {
                    Color.FromArgb(0x000000),
                    Color.FromArgb(0x000080),
                    Color.FromArgb(0x008000),
                    Color.FromArgb(0x008080),
                    Color.FromArgb(0x800000),
                    Color.FromArgb(0x800080),
                    Color.FromArgb(0x808000),
                    Color.FromArgb(0xC0C0C0),
                    Color.FromArgb(0x808080),
                    Color.FromArgb(0x0000FF),
                    Color.FromArgb(0x00FF00),
                    Color.FromArgb(0x00FFFF),
                    Color.FromArgb(0xFF0000),
                    Color.FromArgb(0xFF00FF),
                    Color.FromArgb(0xFFFF00),
                    Color.FromArgb(0xFFFFFF)
                };
    
            public static int sqr(int x)
            {
                return x * x;
            }
    
            public static int colorDistance(Color a, Color b)
            {
                return sqr((a.R - b.R)) + sqr((a.G - b.G)) + sqr((a.B - b.B));
            }
    
    
    
            public static Tuple<ConsoleColor, ConsoleColor, char> ToConsoleColor2(System.Drawing.Color c)
            {
                int bestColori = 0;
                int bestColorj = 0;
                char bestSymbol = '█';
                int bestScore = int.MaxValue;
                for (int ratio = 1; ratio <= 4; ++ratio)
                {
                    for (int i = 0; i < colorTable.Length; ++i)
                    {
                        for (int j = 0; j < colorTable.Length; ++j)
                        {
                            if (ratio > 1 && ratio < 4 && colorDistance(colorTable[i], colorTable[j]) > 50000)
                            {
                                continue;// rule out too weird combinations
                            }
    
                            const int ratioRange = 4;
                            int R = (colorTable[i].R * ratio + colorTable[j].R * (ratioRange - ratio)) / ratioRange;
                            int G = (colorTable[i].G * ratio + colorTable[j].G * (ratioRange - ratio)) / ratioRange;
                            int B = (colorTable[i].B * ratio + colorTable[j].B * (ratioRange - ratio)) / ratioRange;
    
                            int score = colorDistance(c, Color.FromArgb(R, G, B));
    
                            if (score < bestScore)
                            {
                                bestScore = score;
                                bestColori = i;
                                bestColorj = j;
                                switch (ratio)
                                {
                                    case 1: bestSymbol = '░'; break;
                                    case 2: bestSymbol = '▒'; break;
                                    case 3: bestSymbol = '▓'; break;
                                    case 4: bestSymbol = '█'; break;
                                }
                            }
                        }
                    }
                }
                return new Tuple<ConsoleColor, ConsoleColor, char>((ConsoleColor)bestColori, (ConsoleColor)bestColorj, bestSymbol);
            }
    
           
    
            public static void ConsoleWriteImage(Bitmap bmpSrc)
            {
                int sMax = 39;
                decimal percent = Math.Min(decimal.Divide(sMax, bmpSrc.Width), decimal.Divide(sMax, bmpSrc.Height));
                Size resSize = new Size((int)(bmpSrc.Width * percent), (int)(bmpSrc.Height * percent));
    
                Bitmap bmpMax = new Bitmap(bmpSrc, resSize.Width * 2, resSize.Height * 2);
                Bitmap bmpMax2 = new Bitmap(bmpSrc, resSize.Width * 2, resSize.Height);
                for (int i = 0; i < resSize.Height; i++)
                {
    
    
                    for (int j = 0; j < resSize.Width; j++)
                    {
                        Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2, i * 2));
                        Console.BackgroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2, i * 2 + 1));
                        Console.Write("▀");
    
                        Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2 + 1, i * 2));
                        Console.BackgroundColor = (ConsoleColor)ToConsoleColor(bmpMax.GetPixel(j * 2 + 1, i * 2 + 1));
                        Console.Write("▀");
    
                    }
    
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("    ");
    
    
    
                    for (int j = 0; j < resSize.Width; j++)
                    {
                        var best = ToConsoleColor2(bmpMax2.GetPixel(j * 2, i));
                        Console.ForegroundColor = best.Item1;
                        Console.BackgroundColor = best.Item2;
                        Console.Write(best.Item3);
                        best = ToConsoleColor2(bmpMax2.GetPixel(j * 2 + 1, i));
                        Console.ForegroundColor = best.Item1;
                        Console.BackgroundColor = best.Item2;
                        Console.Write(best.Item3);
                    }
                    System.Console.WriteLine();
                }
            }
    
            static void Main(string[] args)
            {
                System.Console.WindowWidth = 170;
                System.Console.WindowHeight = 40;
    
                Bitmap bmpSrc = new Bitmap(@"HuwnC.gif", true);
    
                ConsoleWriteImage(bmpSrc);
    
                System.Console.ReadLine();
            }
        }
    }
