    public static List<bool> GetHash(Bitmap bmpSource)
    {
        List<bool> lResult = new List<bool>();         
        //create new image with 16x16 pixel
        Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
        for (int j = 0; j < bmpMin.Height; j++)
        {
            for (int i = 0; i < bmpMin.Width; i++)
            {
                //reduce colors to true and false
                lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
            }             
        }
        return lResult;
    }
