    public Bitmap LastRow(Bitmap source)
    {
       int y = source.Height - 1;
       Bitmap newSource = new Bitmap(source, y, 1);
       for (int x = 0; x < source.Width; x++)
       {
           NewSource.SetPixel(x, y, Source.GetPixel(x, y));
       }
       return newSource;
    }
