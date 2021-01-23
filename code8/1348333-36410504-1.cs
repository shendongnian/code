    SmtpClient client = new SmtpClient();
    client.Host = "smtp.gmail.com";
    client.Port = 587;
    client.EnableSsl = true;
    client.Credentials = new NetworkCredential("mygmailusername@gmail.com", "mygmailpassword");
                    ////email.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network ;
