    try
    {
        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;
        client.Timeout = 10000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("bazymysql@gmail.com", "xyz");
        MailMessage mm = new MailMessage("donotreply@domain.com", "bazymysql@gmail.com", "Przechwycony ciag znakow", tresc.Text);
        mm.BodyEncoding = UTF8Encoding.UTF8;
        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        Thread sendMailThread = new Thread(()=>{
            client.Send(mm); //This will ensure that your sending happens on a second thread and that it does not crash your main thread.
        });
        sendMailThread.Start();
    }
    catch (SmtpException ex)
    {
        MessageBox.Show(ex.Message);
    }
