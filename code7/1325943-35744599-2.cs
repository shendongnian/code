     byte[] imageBytes = Convert.FromBase64String(base64String);  
        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);  
        ms.Write(imageBytes, 0, imageBytes.Length);  
        System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);  
        return image;  
