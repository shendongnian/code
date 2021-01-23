    public static void MedianFiltering(Bitmap bm)
    {
        List<byte> termsList = new List<byte>();
        byte[,] image = new byte[bm.Width,bm.Height];
        //Convert to Grayscale 
        for (int i = 0; i < bm.Width; i++)
        {
            for (int j = 0; j < bm.Height; j++)
            {
                var c = bm.GetPixel(i, j);
                byte gray = (byte)(.333 * c.R + .333 * c.G + .333 * c.B);
                image[i, j] = gray;
            }
        }
        //applying Median Filtering 
        for (int i = 0; i <= bm.Width - 3; i++)
            for (int j = 0; j <= bm.Height - 3; j++)
            {
                for (int x = i; x <= i + 2; x++)
                    for (int y = j; y <= j + 2; y++)
                    {
                        termsList.Add(image[x, y]);
                    }
                byte[] terms = termsList.ToArray();
                termsList.Clear();
                Array.Sort<byte>(terms);
                Array.Reverse(terms);
                byte color = terms[4];
                bm.SetPixel(i + 1, j + 1, Color.FromArgb(color, color, color));
            }
    }
