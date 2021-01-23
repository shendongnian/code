    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    namespace StackOverflow
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                const String PATH = @"C:\sim\sbro6.png";
                Stopwatch watch = new Stopwatch(); watch.Start();
                List<Bitmap> l_new, l_old;
                {
                    Bitmap bmp = Image.FromFile(PATH) as Bitmap;
                    // Initialization
                    l_old = new List<Bitmap>();
                    l_new = new List<Bitmap>(); l_new.Add(bmp);
                    // Splitting
                    while (l_new.Count > l_old.Count)
                    {
                        l_old = l_new; l_new = new List<Bitmap>();
                        l_new.AddRange(SplitBitmapsVertically(SplitBitmapsHorizontally(l_old)));
                    }
                    // for (Int32 i = 0; i < l_new.Count; i++)
                    // {
                    //     l_new[i].Save(@"C:\sim\bitmap_" + i + ".bmp");
                    // }
                }
                watch.Stop();
                Console.WriteLine("Picture analyzed in ".PadRight(59,'.') + " " + watch.Elapsed.TotalSeconds.ToString("#,##0.0000"));
                Console.WriteLine("Dots found ".PadRight(59, '.') + " " + l_new.Count);
                Console.WriteLine();
                Console.WriteLine("[ENTER] terminates ...");
                Console.ReadLine();
            }
            static List<Bitmap> SplitBitmapsVertically(List<Bitmap> l_old)
            {
                Int32 x_start = -1; Bitmap bmp; Boolean colContainsData = false;
                List<Bitmap> l = new List<Bitmap>();
                foreach(Bitmap b in l_old)
                {
                    for (Int32 x = 0; x < b.Width; x++)
                    {
                        colContainsData = false;
                        for (Int32 y = 0; y < b.Height; y++)
                        {
                            if (b.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                            {
                                colContainsData = true;
                            }
                        }
                        if (colContainsData) if (x_start < 0) { x_start = x; }
                        if (!colContainsData || (x == (b.Width - 1))) if (x_start >= 0)
                            {
                                bmp = new Bitmap(x - x_start, b.Height);
                                for (Int32 x_tmp = x_start; x_tmp < x; x_tmp++)
                                    for (Int32 y_tmp = 0; y_tmp < b.Height; y_tmp++)
                                    {
                                        bmp.SetPixel(x_tmp - x_start, y_tmp, b.GetPixel(x_tmp, y_tmp));
                                    }
                                l.Add(bmp); x_start = -1;
                            }
                    }
                }
                return l;
            }
            static List<Bitmap> SplitBitmapsHorizontally(List<Bitmap> l_old)
            {
                Int32 y_start = -1; Bitmap bmp; Boolean rowContainsData = false;
                List<Bitmap> l = new List<Bitmap>();
                foreach (Bitmap b in l_old)
                {
                    for (Int32 y = 0; y < b.Height; y++)
                    {
                        rowContainsData = false;
                        for (Int32 x = 0; x < b.Width; x++)
                        {
                            if (b.GetPixel(x, y).ToArgb() != Color.White.ToArgb())
                            {
                                rowContainsData = true;
                            }
                        }
                        if (rowContainsData) if (y_start < 0) { y_start = y; }
                        if (!rowContainsData || (y == (b.Height - 1))) if (y_start >= 0)
                            {
                                bmp = new Bitmap(b.Width, y - y_start);
                                for (Int32 x_tmp = 0; x_tmp < b.Width; x_tmp++)
                                    for (Int32 y_tmp = y_start; y_tmp < y; y_tmp++)
                                    {
                                        bmp.SetPixel(x_tmp, y_tmp - y_start, b.GetPixel(x_tmp, y_tmp));
                                    }
                                l.Add(bmp); y_start = -1;
                            }
                    }
                }
                return l;
            }
        }
    }
