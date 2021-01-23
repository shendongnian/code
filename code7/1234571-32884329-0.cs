    [WebMethod]
    public static void bntChangeOpacity_Click1(object sender, EventArgs e)
    {
        string s = txtOp.Value;
        float ss = float.Parse(s);
        float opacityvalue = ss / 10;
        var img = ImageTransparency.ChangeOpacity(Image.FromFile(HttpContext.Current.Server.MapPath("img1.jpg")), opacityvalue);
        img.Save(HttpContext.Current.Server.MapPath("img2.jpg"));
    }
