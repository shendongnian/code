    namespace SMTPCert
    {
        public static string CertificateDaysLeft;
        public static string GetSMTPCert(string ServerName)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
            using (System.Net.Mail.SmtpClient S = new System.Net.Mail.SmtpClient(ServerName))
            {
                S.EnableSsl = true;
                using (System.Net.Mail.MailMessage M = new System.Net.Mail.MailMessage("test@example.com", "test@example.com", "Test", "Test"))
                {
                    try
                    {
                        S.Send(M);
                        string daysLeft = CertificateDaysLeft;
                        return daysLeft;
                    }
                    catch (Exception)
                    {
                        string daysLeft = CertificateDaysLeft;
                        return daysLeft;
                    }
                }
            }
        }
        private static bool RemoteServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            DateTime ExpirDate = Convert.ToDateTime(certificate.GetExpirationDateString());
            string DaysLeft = Convert.ToString((ExpirDate - DateTime.Today).Days);
            CertificateDaysLeft = DaysLeft;
            Console.WriteLine(certificate);
            return true;
        }
    }
