    using (Stream s = File.OpenRead("myJpeg.jpg"))
    {
        Image sourceImage = Image.FromStream(s);
    
        Graphics canvas = Graphics.FromImage(sourceImage);
        canvas.DrawLine(new Pen(Color.Black, 5), 0, 0, sourceImage.Width, sourceImage.Height);
        sourceImage.Save("test.jpg");
    }
