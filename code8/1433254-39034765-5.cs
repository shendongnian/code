     public void ConvertHtmlToImage()
    {
      
      System.Drawing.Image img = HtmlRender.RenderToImage(html, new Size(400, 200), Color.Linen);//html is the varialbe obtained above
       img.Save(Server.MapPath("/Images/save.jpg"), ImageFormat.Jpeg);
    }
