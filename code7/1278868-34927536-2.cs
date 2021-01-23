        using (var ia = new ImageAttributes())
    {
        ia.SetColorMatrix(new ColorMatrix(gray_matrix));
        ia.SetThreshold(0.8f, ColorAdjustType.Default);
        //gr.DrawImage(b, new Rectangle(0, 0, (int)(b.Width * (1 + (percent / 100))), (int)(b.Height * (1 + (percent / 100)))), 0, 0, (int)(b.Width * (1 + (percent / 100))), (int)(b.Height * (1 + (percent / 100))), GraphicsUnit.Pixel, ia);
        gr.DrawImage(b, new Rectangle(0, 0, (int)(b.Width * (1 + (percent / 100))), (int)(b.Height * (1 + (percent / 100)))), new Rectangle(0, 0, (int)(b.Width * (1 + (percent / 100))), (int)(b.Height * (1 + (percent / 100)))), GraphicsUnit.Pixel);
        //gr.DrawImage(b, new Rectangle(0, 0, (int)(b.Width * (1 + (percent / 100))), (int)(b.Height * (1 + (percent / 100)))), new Rectangle(0, 0, b.Width, b.Height), GraphicsUnit.Pixel);
        string myHeight;
        string myWidth;
        ImHeight = (int)(b.Height * (1 + (percent / 100)));
        ImWidth = (int)(b.Width * (1 + (percent / 100)));
        myHeight = ImHeight.ToString(); ;
        myWidth = ImWidth.ToString(); ;
        Response.Cookies["TiffViewer"]["ReturnURL"] = c["ReturnURL"];
        Response.Cookies["TiffViewer"]["Key"] = c["Key"];
        Response.Cookies["TiffViewer"]["ImHeight"] = myHeight;
        Response.Cookies["TiffViewer"]["ImWidth"] = myWidth;
        Response.Cookies["TiffViewer"]["PageCount"] = c["PageCount"];
    }
