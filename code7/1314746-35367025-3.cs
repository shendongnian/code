    public static Bitmap Scale(this Bitmap inputImage, Size newSize)
    {
        var outputImage = new Bitmap(newSize.Width, newSize.Height);
    
        inputImage.Save(@"M:\Coding\Photos\Temp\input.jpg");
        using (Graphics gr = Graphics.FromImage(outputImage))
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gr.DrawImage(inputImage, new Rectangle(0, 0, newSize.Width, newSize.Height));
        }
        outputImage.Save(@"M:\Coding\Photos\Temp\output.jpg");
    
        return outputImage;
    }
