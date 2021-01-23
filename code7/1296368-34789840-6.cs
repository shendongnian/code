            using (var message = new MailMessage
            {
                From = new MailAddress("from@gmail.com"),
                Subject = "This is subject.",
                Body = "This is text.",
                IsBodyHtml = true,
                To = { "to@someDomain.com" }
            })
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    message.Attachments.Add(new Attachment(imageFile.InputStream, imageFile.ContentType, MediaTypeNames.Image.Jpeg));
                }
                using (var client = new SmtpClient("smtp.gmail.com")
                {
                    Credentials = new System.Net.NetworkCredential("user", "password"),
                    EnableSsl = true
                })
                {
                    client.Send(message);
                }
            }
