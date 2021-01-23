    static Bitmap Embed(string fname, string message)
    {
        Bitmap img = new Bitmap(fname);
        byte[] msgBytes = System.Text.Encoding.UTF8.GetBytes(message);
        
        int nbytes = msgBytes.Length;
        int ibit = 7;
        int ibyte = 0;
        byte currentByte = msgBytes[ibyte];
        
        for (int i = 0; i < img.Height; i++)
        {
            for (int j = 0; j < img.Width; j++)
            {
                Color pixel = img.GetPixel(i, j);
                int lsb = (msgBytes[ibyte] >> ibit) & 1;
                Color newpixel = Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B ^ (lsb << 1));
                img.SetPixel(i, j, newpixel);
                ibit--;
                if (ibit == -1)
                {
                    ibit = 7;
                    ibyte++;
                    if (ibyte == nbytes)
                    {
                        return img;
                    }
                    currentByte = msgBytes[ibyte];
                }
            }
        }
        return img;
    }
