        private static void SetSmtpDetails()
         {
            ConfigurationModel smtpConfig = GetConfiguration(ConfigurationKey.SMTPServer.ToString());
            string smtpServerValue = smtpConfig.Value;
            ConfigurationModel smtpUserConfig = GetConfiguration(ConfigurationKey.SMTPUser.ToString());
            string smtpUserValue = smtpUserConfig.Value;
            ConfigurationModel smtpPasswordConfig = GetConfiguration(ConfigurationKey.SMTPPassword.ToString());
            string smtpPAsswordValue = smtpPasswordConfig.Value;
            ConfigurationModel smtpSslConfig = GetConfiguration(ConfigurationKey.EnableSsl.ToString());
            string smtpEnableSSl = smtpSslConfig.Value;
            ConfigurationModel portConfig = GetConfiguration(ConfigurationKey.Port.ToString());
            SmtpServer = !string.IsNullOrEmpty(smtpServerValue) ? Convert.ToString(smtpServerValue) : SmtpServer;
            SmtpUser = !string.IsNullOrEmpty(smtpUserValue) ? Convert.ToString(smtpUserValue) : SmtpUser;
            SmtpPassword = !string.IsNullOrEmpty(smtpPAsswordValue) ? Convert.ToString(smtpPAsswordValue) : SmtpPassword;
            EnableSsl = !string.IsNullOrEmpty(smtpEnableSSl) ? Convert.ToBoolean(smtpEnableSSl) : EnableSsl;
            Port = Convert.ToInt32(portConfig.Value);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }
  
    public static bool SendMail(string fromAddress, string toAddress, string ccAddress, string bccAddress, string subject, string bodyMessage, bool isBodyHtml, string fileName, string fromName)
        {
            SetSmtpDetails();
            if (string.IsNullOrEmpty(fromAddress))
            {
                fromAddress = SmtpUser;
            }
            try
            {
                var mailMessage = new MailMessage();
                if (ccAddress != null && ccAddress.Trim().Length > 0)
                {
                    mailMessage.CC.Add(ccAddress);
                }
                if (bccAddress != null && bccAddress.Trim().Length > 0)
                {
                    mailMessage.Bcc.Add(bccAddress);
                }
                mailMessage.To.Add(toAddress);
                if (fromAddress != null && fromAddress.Trim().Length > 0)
                {
                    if (fromName != null && fromName.Trim().Length > 0)
                    {
                        mailMessage.From = new MailAddress(fromAddress, fromName);
                    }
                    else
                    {
                        mailMessage.From = new MailAddress(fromAddress);
                    }
                }
                subject = subject.Replace('\r', ' ').Replace('\n', ' ');
                bodyMessage = bodyMessage.Replace("\r\n", "<br />");
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Subject = subject;
                mailMessage.Body = bodyMessage;
                mailMessage.IsBodyHtml = isBodyHtml;
                mailMessage.Priority = MailPriority.High;
                if (fileName != null && fileName.Trim().Length > 0 && File.Exists(fileName))
                {
                    mailMessage.Attachments.Add(new Attachment(fileName));
                }
                var client = new SmtpClient();
                try
                {
                    client.Host = SmtpServer;
                    client.Port = Port;
                    client.Credentials = new NetworkCredential(fromAddress, SmtpPassword);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = EnableSsl;
                    client.UseDefaultCredentials = true;
                    ThreadPool.QueueUserWorkItem(o =>
                                client.SendAsync(mailMessage, Tuple.Create(client, mailMessage)));
                }
                catch (SmtpException smtpEx)
                {
                    if (smtpEx.Message.Contains("secure connection"))
                    {
                        client.EnableSsl = true;
                        client.Send(mailMessage);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("Error occured while sending Email  : From Address: {0} \r\n - ToAddress : {1} \r\n ", fromAddress, toAddress), ex);
            }
            return true;
        }
