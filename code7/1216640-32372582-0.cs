        string AppPath = Request.PhysicalApplicationPath;
        StreamReader sr = new StreamReader(AppPath + "EmailTemplates/EmailTemplate.txt");
        message.IsBodyHtml = true;
        message.Body = sr.ReadToEnd();
        sr.Close();
