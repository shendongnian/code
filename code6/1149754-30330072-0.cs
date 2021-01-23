    using (mmMessage)
            {
                mmMessage.Subject = strSubject;
                mmMessage.Body = strBody;
                mmMessage.IsBodyHtml = blnIsBodyHTML;
                mmMessage.Headers.Add("Reply-To", FromEmailAddress);
                SmtpClient smtp = new SmtpClient();
                using (smtp)
                {
                    smtp.Host = SMTPServer;
                    smtp.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPwd);
                    smtp.Port = Port;
                    //smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = IsEnableSsl;
                    smtp.Send(mmMessage);
                }
            }
