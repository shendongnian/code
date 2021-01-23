        var res = from c in ctx.Default_Email_Creds select new {c.Hostname, c.UserName, c.Password, c.Mail_From}.FirstOrDefault();
        if(res != null)
        {
            serverHostname = res.Hostname;
            serverUsername  = res.UserName;
            serverPassword  = res.Password;
            mailFrom  = res.Mail_From;
        }
        
