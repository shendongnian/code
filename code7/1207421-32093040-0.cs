     var source = Bitmap.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Безымянный.png");
     using (FastBitmap sourceBitmap = new FastBitmap(source))
            {
                for (int TY = 0; TY < 4; TY++)
                {
                    for (int TX = 0; TX < 4; TX++)
                    {
                        Color color = sourceBitmap.GetPixel(TX, TY);
                        Console.Write(color.B.ToString().PadLeft(5));
                    }
                    Console.WriteLine();
                }
            }
