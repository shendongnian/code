    using System.Net;
    using System.Net.Mail;
    using System.Configuration;
    static void Main(string[] args)
    {
       SendEmail("Lukeriggz@gmail.com", "This is a Test email", "This is where the Body of the Email goes");
    }
    public static void SendEmail(string sTo, string subject, string body)
    {
        var Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        using (var client = new SmtpClient(Your EmailHost, Port))
        using (var message = new MailMessage()
        {
            From = new MailAddress(FromEmail),
            Subject = subject,
            Body = body
        })
        {
            message.To.Add(sTo);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailCredential"],
                    ConfigurationManager.AppSettings["EmailPassword"]);
            client.EnableSsl = true;
            client.Send(message);
        };
    }
