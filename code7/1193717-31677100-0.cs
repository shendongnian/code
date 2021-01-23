    SmtpClient client = new SmtpClient();
    client.Port = your port;
    client.Host = your host;
    client.EnableSsl = true;
    client.Timeout = 15000;
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.UseDefaultCredentials = false;
    client.Credentials = new System.Net.NetworkCredential(your username, your passowrd);
    MailMessage mm = new MailMessage(your username, recepient[0], title, message);
    for (int a = 1; a < recepient.Count; a++)
        mm.To.Add(recepient[a]);
    mm.BodyEncoding = UTF8Encoding.UTF8;
    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    client.SendCompleted += (s, e) =>
    {
        client.Dispose();
        mm.Dispose();
    };
    client.SendAsync(mm, null);
