    string imgPath = Server.MapPath("~/App_Files/" + Profile.CompanyName + "/Temp/test.jpg");
    Bitmap source = new Bitmap(imgPath);
    source.MakeTransparent();
    for (int x = 0; x < source.Width; x++)
    {
        for (int y = 0; y < source.Height; y++)
        {
            Color currentColor = source.GetPixel(x, y);
            if (currentColor.R >= 220 && currentColor.G >= 220 && currentColor.B >= 220)
            {
                source.SetPixel(x, y, Color.Transparent);
            }
        }
    }
    source.Save(imgPath);
