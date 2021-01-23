    [System.Web.Services.WebMethod]
    public static void ChangeOpacity()
        {
            string s = txtOp.Value;
            float ss = float.Parse(s);
            float opacityvalue = ss / 10;
            var img = ImageTransparency.ChangeOpacity(Image.FromFile(Server.MapPath("img1.jpg")), opacityvalue);
            img.Save(Server.MapPath("img2.jpg"));
    
        }
