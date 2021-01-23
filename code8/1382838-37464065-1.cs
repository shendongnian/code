        public static void SendMail(string fromAccount, string toAccount, string subject, string eMailText)
        {
            if (!IsValidEMail(toAccount))
            {
                var invalidEMailAddress = toAccount;
                toAccount = "administrator@YOUR-DOMAIN.com";
                subject = "E-Mail-Address is invalid";
                eMailText = String.Format("Dear Administrator,<br><br>the following E-Mail-Address is invalid:<br><br>{0}", invalidEMailAddress);
            }
            
            var fromEmailAddress = new EMailModel(fromAccount);
            var body = string.Empty;
            using (var sr = new StreamReader(HostingEnvironment.MapPath("\\App_Data\\Templates\\") + "EMailTemplate.txt"))
            {
                body = sr.ReadToEnd();
            }
            body = body.Replace("%%Subject%%", subject);
            body = body.Replace("%%Body%%", eMailText);
            body = body.Replace("%%Year%%", DateTime.Now.Year.ToString());
            using (MailMessage mail = new MailMessage(fromEmailAddress.EMailAddress, toAccount))
            {
                mail.Subject = subject;
                mail.Body = WebUtility.HtmlDecode(body);
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(Statics.SmtpClient, Statics.SmtpPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(fromEmailAddress.EMailAddress, fromEmailAddress.Password);
                    smtp.EnableSsl = Statics.SslEnabled;
                    try
                    {
                        smtp.Send(mail);
                        Thread.CurrentThread.Join(1000);
                    }
                    catch (Exception) { }
                }
            }
        }
