    //saving image as stream , send email with stream online  and finally save stream to disk
        public void Test3(string fromEmailAddress, string password)
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
                    //saving the image to a MemoryStream, and then providing that MemoryStream to the attachment constructor:
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    stream.Position = 0;
                }
                //add stream with defined friendly filename and mediaType as attachment
                Attachment attachment = new Attachment(stream, fname, MediaTypeNames.Image.Jpeg);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmailAddress);
                mail.To.Add(fromEmailAddress);
                mail.Subject = "Test send image";
                mail.Body = "mail with image attachment";
                mail.Attachments.Add(attachment);
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(fromEmailAddress, password);
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
                //write stream to file , close stream
                using (FileStream file = new FileStream(fname, FileMode.Create, FileAccess.Write))
                {
                    stream.Position = 0;
                    stream.WriteTo(file);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
