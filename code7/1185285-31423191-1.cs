    I would suggest you to do this way.
    1. Create a application setting:
      
    
          <appSettings >
            <add key="ImgFolderPath" value="c:\ASP\ODIYA_Doctor_Admin\Upload\Banner"/>
          </appSettings>
    2. Change your aspx code:
    
        <img runat="server" id="imgCtrl" src='<%# resizeAndConvertToBase64( Convert.ToString(Eval("Bnr_Image")),1920,680) %>' class="ls-bg" />
    
    3. Change your .cs page code:
     
    
    protected string resizeAndConvertToBase64(string imageName, int newWidth, int newHeight)
                {
                    Bitmap newImage = new Bitmap(newWidth, newHeight);
                    string path = ConfigurationManager.AppSettings["ImgBaseAddress"].ToString();
                    System.Drawing.Image srcImage = System.Drawing.Image.FromFile(path+"/"+imageName));
                    using (Graphics gr = Graphics.FromImage(newImage))
                    {
                        gr.SmoothingMode = SmoothingMode.HighQuality;
                        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
        
                    }
                        MemoryStream ms = new MemoryStream();
                        newImage.Save(ms, ImageFormat.Gif);
                        var base64Data = Convert.ToBase64String(ms.ToArray());
                        return "data:image/gif;base64," + base64Data;
                    }
