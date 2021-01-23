    public static Bitmap RainbowFilterParallel(Bitmap bmp)
    {
        Bitmap temp = new Bitmap(bmp);
        int raz = bmp.Height / 4;
        int height = bmp.Height;
        int width = bmp.Width;
        // set a limit to parallesim
        int maxCore = 7;
        int blockH = height / maxCore + 1;
        //lock (temp) 
        Parallel.For(0, maxCore, cor =>
        {
            //Parallel.For(0, bmp.Height, x =>
            for (int yb = 0; yb < blockH; yb++)
            {
                int i = cor * blockH + yb;
                if (i >= height) continue;
                for (int x = 0; x < width; x++)
                {
                    {
                      Color c;
                      // lock the Bitmap just for the GetPixel: 
                      lock (temp) c  = temp.GetPixel(x, i);
                      byte R = c.R;
                      byte G = c.G;
                      byte B = c.B;
                      if (i < (raz)) { R = (byte)(c.R / 5); }
                      else if (i < raz + raz) { G = (byte)(c.G / 5); }
                      else if (i < raz * 3) { B = (byte)(c.B / 5); }
                      else if (i < raz * 4) { R = (byte)(c.R / 5); B = (byte)(c.B / 5); }
                      else { G = (byte)(c.G / 5); R = (byte)(c.R / 5); }
                      // lock the Bitmap just for the SetPixel:
                      lock (temp) temp.SetPixel(x, i, Color.FromArgb(R,G,B));
                    };
                }
            };
        });
        return temp;
    }
