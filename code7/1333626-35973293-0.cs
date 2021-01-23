    for (int i = 0; i < img.Width; i++)
    {           
        for (int j = 0; j < img.Height; j++)
        {
            string rl = sr.ReadLine();
            img.SetPixel(i, j, Color.FromArgb(Int32.Parse(rl)));
        }
    }
