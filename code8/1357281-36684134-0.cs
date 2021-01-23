      {
           using(Image returnImg = Image.FromFile(@"C:\...\Temp\" + id + "1" + ".jpeg"))
           {
           using(MemoryStream memoryStream = new MemoryStream())
           {
           returnImg.Save(memoryStream, ImageFormat.Jpeg);
        
           var message = new HttpResponseMessage(HttpStatusCode.OK)
           {
              Content = new ByteArrayContent(memoryStream.ToArray())
           };
    }
           message.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
    }
           File.Delete(@"C:\...\Temp\" + id + "1" + ".jpeg"); //error is on this line execution
           return message
         }
