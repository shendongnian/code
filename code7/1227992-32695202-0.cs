            string from = "info@Oursystem.com"; 
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                mail.To.Add("user1@Oursystem.com");
                mail.To.Add("user2@Oursystem.com");
            }
