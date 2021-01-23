        Bitmap bitMapImage = new
           System.Drawing.Bitmap(Server.MapPath(imageurl));
        Graphics graphicImage = Graphics.FromImage(bitMapImage);
        graphicImage.SmoothingMode = SmoothingMode.AntiAlias; 
        graphicImage.DrawString(TextBox1.Text,
             new Font("Times New Roman", 24, FontStyle.Bold),
              new SolidBrush(Color.White), new Point(200, 350));
      Response.ContentType = "image/jpeg";
      bitMapImage.Save (Response.OutputStream, ImageFormat.Jpeg);
