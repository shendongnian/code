using System.Net.Mail;
    private bool EmailVerify(string email)
    
        {
            try
            {
                var mail = new MailAddress(email);
                return mail.Host.Contains(".");
            }
            catch
            {
                return false;
            }
        }
