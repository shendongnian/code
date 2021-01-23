    using System.Drawing;
    public static void ConsoleWriteImage(Bitmap bmpSrc)
    {
        int sMax = 39;
        decimal percent = Math.Min(decimal.Divide(sMax, bmpSrc.Width), decimal.Divide(sMax, bmpSrc.Height));
        Size resSize = new Size((int)(bmpSrc.Width * percent), (int)(bmpSrc.Height * percent));
        Func<System.Drawing.Color, int> ToConsoleColor = c =>
        {
            int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0; 
            index |= (c.R > 64) ? 4 : 0;
            index |= (c.G > 64) ? 2 : 0;
            index |= (c.B > 64) ? 1 : 0; 
            return index;
        };
        Bitmap bmpMin = new Bitmap(bmpSrc, resSize);
        for (int i = 0; i < resSize.Height; i++)
        {
            for (int j = 0; j < resSize.Width; j++)
            {
                Console.ForegroundColor = (ConsoleColor)ToConsoleColor(bmpMin.GetPixel(j, i));
                Console.Write("██");
            }
            System.Console.WriteLine();
        }
    }
