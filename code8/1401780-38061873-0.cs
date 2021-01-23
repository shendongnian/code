    using (MagickImage image = new MagickImage(pathToTiffFile))
    {
        image.Threshold(60); // 60 is OK 
        image.Depth = 1;
        image.Write(pathToOutputFile);
    }
