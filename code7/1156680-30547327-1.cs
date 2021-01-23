    StringBuilder sb = new StringBuilder();
    for (int y = 0; y < image.Height; y++)
    {
        for (int x = 0; x < image.Width; x++)
        {
            Color pixel = image.GetPixel(x, y);
            sb.AppendLine("Value at" + x + "" + y + "" + "is:" + pixel);
            if (pixel.R == keywordBytes[0] && pixel.G == keywordBytes[1] && pixel.B == keywordBytes[2])
            {
                firstMatchingBytePos = new Point(x, y);
                KeywordFound(keyword, firstMatchingBytePos);
            }
        }
    }
    string path = @"E:\Example.txt";
    if (!File.Exists(path))
    {
        File.Create(path);
    }
    File.AppendAllText(path, sb.ToString());
