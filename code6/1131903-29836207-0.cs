         SmtpClient client = new SmtpClient();
         client.DeliveryMethod = SmtpDeliveryMethod.Network;
         client.EnableSsl = true;
         client.Host = "smtp.gmail.com";
         client.Port = 587;
         client.Credentials = new System.Net.NetworkCredential("xxxx@gmail.com", "xxxx");
