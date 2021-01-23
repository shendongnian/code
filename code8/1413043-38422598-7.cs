      public void Test2(string fromEmailAddress, string password)
        {
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Height = 100;
            var fname = @"wisesoftware.jpg";
            try
            {
                var stream = new MemoryStream();
                using (Bitmap bitmap = new Bitmap(800, webBrowser.Height))
                {
                    webBrowser.DrawToBitmap(bitmap, new Rectangle(0, 0, 800, bitmap.Height));
                    bitmap.Save(fname, ImageFormat.Jpeg);
                    //saving the image to a MemoryStream, and then providing that MemoryStream to the attachment constructor:
                    
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    stream.Position = 0;
                    
                }
                Attachment attachment = new Attachment(fname, MediaTypeNames.Application.Octet);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmailAddress);
                mail.To.Add(fromEmailAddress);
                mail.Subject = "Test send image";
                mail.Body = "mail with image attachment";
                mail.Attachments.Add(new Attachment(stream, "image/jpg"));
               // mail.Attachments.Add(attachment);
                if (File.Exists(fname))
                {
                    smtpServer.Port = 587;
                    smtpServer.Credentials = new NetworkCredential(fromEmailAddress, password);
                    smtpServer.EnableSsl = true;
                    smtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
