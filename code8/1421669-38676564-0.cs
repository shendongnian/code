     NetworkCredential cr = new NetworkCredential();
     cr.UserName = "User from AD DS";
     cr.Password = "Password of User";
     client.Credentials = cr; 
     client.UseDefaultCredentials = false;
     client.DeliveryMethod = SmtpDeliveryMethod.Network;
     client.Port = 25;
     client.Timeout = 10000;
     client.Send(activationMail);
