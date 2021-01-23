    Image ImgPic = Image.FromFile("AvtarPic.png");
    Image FranceFlagOverlay = Image.FromFile("FranceFlag.png");
    
    Image img = new Bitmap(ImgPic.Width, ImgPic.Height);
    using (Graphics gr = Graphics.FromImage(img))
    {
        gr.DrawImage(ImgPic, new Point(0, 0));
        gr.DrawImage(FranceFlagOverlay, new Point(0, 0));
    }
    img.Save("ImgPicWithFranceFlagOverlay.png", ImageFormat.Png);
