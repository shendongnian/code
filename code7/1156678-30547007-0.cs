    string path = @"E:\Example.txt";
    for (int y = 0; y < image.Height; y++)
    {
        for (int x = 0; x < image.Width; x++)
        {
            Color pixel = image.GetPixel(x, y);
         
            // this line is all you need to append a line to an existing, OR NEW file
            File.AppendText(path, "\nValue at" + x + "" + y + "" + "is:" + pixel);
            if (pixel.R == keywordBytes[0] && pixel.G == keywordBytes[1] && pixel.B == keywordBytes[2])
            {
                firstMatchingBytePos = new Point(x, y);
                KeywordFound(keyword, firstMatchingBytePos);
            }
        }
    } 
