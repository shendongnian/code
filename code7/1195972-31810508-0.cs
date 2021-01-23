    public void Main()
    {
        MailMessage mail = new MailMessage("from@email.com", "to@gmail.com", "subject", "body");
        SmtpClient client = new SmtpClient("smtp.office365.com", 587);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("from@email.com", "password!!!");
        client.Send(mail);
        Dts.TaskResult = (int)ScriptResults.Success;
    }
