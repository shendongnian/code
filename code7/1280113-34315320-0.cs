    protected void Page_Load(object sender, EventArgs e)
    {
        string filePath = Server.MapPath("~/Images/41LR9-Q2W-L._AC_UX500_SY400_.jpg");
        if (File.Exists(filePath))
        {
            Byte[] bytes = File.ReadAllBytes(filePath);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            ASPxImageZoom1.ImageUrl = "data:image/png;base64," + base64String;    
        }            
    }
