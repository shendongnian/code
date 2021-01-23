    protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile filePosted = Request.Files["newinput"];
            string base64String = filePosted.ToString();
    
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
    
                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image   = System.Drawing.Image.FromStream(ms, true);
                string newFile = Guid.NewGuid().ToString() + fileExtensionApplication;
                string filePath = Path.Combine(Server.MapPath("~/Assets/") + Request.QueryString["id"] + "/", newFile);
                image.Save(filepath,ImageFormat.Jpeg);
       }
