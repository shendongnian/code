    public static Complex[,] Unwrap(Bitmap bitmap)
    {
      int Width = bitmap.Width;
      int Height = bitmap.Height;
      Complex[,] array2D = new Complex[bitmap.Width, bitmap.Height];
      ...
            else// If there is only one channel:
            {
              iii = (int)(*address);
              if (iii >= 128)
              {
                iii -= 256;
              }
            }
            Complex tempComp = new Complex((double)iii, 0.0);
            array2D[x, y] = tempComp;
