    using AForge.Imaging.ColorReduction;
    void reduceColors(string inFile, string outFile, int numColors)
    {
        using (Bitmap image = new Bitmap(inFile) )
        {
            ColorImageQuantizer ciq =    new ColorImageQuantizer(new MedianCutQuantizer());
            Color[] colorTable = ciq.CalculatePalette(image, numColors);
            using (Bitmap newImage = ciq.ReduceColors(image, numColors))
                newImage.Save(outFile);
        }
    }
