    var footer = Image.FromFile("path_to_your_footer.png");      
    imageByte= Convert.FromBase64String(ImageUrl);
             using (var streamBitmap = new MemoryStream(imageByte))
                {
                    using (var img = Image.FromStream(streamBitmap))
                    {
                          var imageWithFooter = AppendImageFooter(img, footer);
                          imageWithFooter.Save(localPath);
        
                     }
                 }
