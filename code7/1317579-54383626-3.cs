    [Route("[action]")]
    [HttpPost]
    public void Html2Pdf([FromBody] JObject jObject)
    {
        dynamic obj = jObject;
        try
        {
            string strJson = obj.pdfContent;
            var match = Regex.Match(strJson, @"data:application/pdf;filename=generated.pdf;base64,(?<data>.+)");
            var base64Data = match.Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            using (var memoryStream = new MemoryStream())
            {
                var mail = new MailMessage
                {
                    From = new MailAddress("[FromEmail]")
                };
                mail.To.Add("");
                mail.Subject = "";
                mail.Body = "attached";
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(new MemoryStream(binData), "htmlToPdf.pdf"));
                var SmtpServer = new SmtpClient("[smtp]")
                {
                    Port = 25,
                    Credentials = new NetworkCredential("[FromEmail]", "password"),
                    EnableSsl = true
                };
                SmtpServer.Send(mail);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
