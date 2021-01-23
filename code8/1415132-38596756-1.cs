    private void Init()
    {
        UpdateNLogConfig(null, null);
        LogManager.ConfigurationReloaded += UpdateNLogConfig;
    }
    
    private void UpdateNLogConfig(object sender, LoggingConfigurationReloadedEventArgs e)
    {
    
        var target = new MailTarget();
        target.Name = "Mailing";
        target.Html = true;
        target.Body = "${message}";
        target.SmtpServer = EmailSending.SendingServer;
        target.From = EmailSending.EmailSender;
        target.Encoding = System.Text.Encoding.UTF8;
        target.To = EmailSending.EmailReceiver;
        target.EnableSsl = EmailSending.EnableSSl;
        target.SmtpPort = EmailSending.sendingPort;
        target.SmtpUserName = EmailSending.EmailSender;
        target.SmtpPassword = EmailSending.EmailsenderPw;
        LogManager.Configuration.AddTarget("Mailing", target);
        LogManager.Configuration.AddRuleForOneLevel(LogLevel.Fatal, target); //or LogManager.Configuration.LoggingRules.Add(new LoggingRule("*", LogLevel.Fatal,target));
    }
