    List<bool> lResult = new List<bool>();
    Bitmap bmpSource = new Bitmap(@"C:\mykoala.jpg");      
    //create new image with 16x16 pixel
    Bitmap bmpMin = new Bitmap(bmpSource, new Size(16,16));
    for (int i = 0; i < bmpMin.Height; i++)
    {
        for (int j = 0; j < bmpMin.Width; j++)
        {
            //reduce colors to true and false
            lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
        }
    }
