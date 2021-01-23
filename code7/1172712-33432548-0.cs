     public override AlternateView PopulateHtmlPart(MailMessage mailMessage, string viewName, string masterName, Dictionary<string, string> linkedResources)
        {
            var htmlPart = base.PopulateHtmlPart(mailMessage, viewName, masterName, linkedResources);
            htmlPart.ContentType.CharSet = mailMessage.BodyEncoding.HeaderName;
            return htmlPart;
        }  
