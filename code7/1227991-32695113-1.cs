    string from = test@test.com;
    string to = test123@testing.com;
    string to1 =test1234@testing.com;
    
    mail.From = new System.Net.Mail.MailAddress(from);
    mail.To.Add(new System.Net.Mail.MailAddress(to));
    mail.To.Add(new System.Net.Mail.MailAddress(to1));
