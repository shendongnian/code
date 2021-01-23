    Image img = //...;
    PictureBox pb = //...;
    var wfactor = (double)img.Width / pb.ClientSize.Width;
    var hfactor = (double)img.Height / pb.ClientSize.Height;
    var resizeFactor = Math.Max(wfactor, hfactor);
    var imageSize = new Size((int)(img.Width / resizeFactor), (int)(img.Height / resizeFactor));
