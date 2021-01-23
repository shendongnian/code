    // show before
    pbWM.Image = Image.FromFile(@"C:\Temp\horus_w.png");
    
    using (Image watermark = Image.FromFile(@"C:\Temp\horus_w.png"))
    using (Image TargetImg = Image.FromFile(@"C:\Temp\BigHead.jpg"))
    using (Graphics g = Graphics.FromImage(TargetImg))
    {
        var destX = (TargetImg.Width - watermark.Width) - 10;
        var destY = (TargetImg.Height - watermark.Height) - 10;
    
        g.DrawImage(watermark, new Rectangle(destX,
                    destY,
                    watermark.Width,
                    watermark.Height));
        // display a clone for demo purposes
        pb2.Image = (Image)TargetImg.Clone();
    }
