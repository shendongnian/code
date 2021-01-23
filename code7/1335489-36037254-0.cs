using System.Net.Mail;
    private bool EmailVerify(string email)
    
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
