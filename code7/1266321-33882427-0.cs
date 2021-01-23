     static void Main(string[] args)
            {
                var validMail = "validMail@gmail.com";
                var invalidMail = "123";
                Console.WriteLine("IsValidMailAddress1 Test");
                Console.WriteLine(string.Format("Mail Address : {0} . is valid : {1}", validMail, IsValidMailAddress1(validMail)));
                Console.WriteLine(string.Format("Mail Address : {0} . is valid : {1}", invalidMail, IsValidMailAddress1(invalidMail)));
    
                Console.WriteLine("IsValidMailAddress2 Test");
                Console.WriteLine(string.Format("Mail Address : {0} . is valid : {1}", validMail, IsValidMailAddress2(validMail)));
                Console.WriteLine(string.Format("Mail Address : {0} . is valid : {1}", invalidMail, IsValidMailAddress2(invalidMail)));
    
            }
    
    
            static bool IsValidMailAddress1(string mail)
            {
                try
                {
                    System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(mail);
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
            static bool IsValidMailAddress2(string mailAddress)
            {
                return Regex.IsMatch(mailAddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            }
