    foreach (var mailItem in emails)
    {
        string email = mailItem.Trim();
        templateData = mailEntitiyData.HtmlContent;             
        var customTemplateData = templateData.Replace("##FULL_NAME##", customer.Name + " " + customer.Surname);
        var postRes = mh.SendMail(subject, customTemplateData, email, postType, null, null, bytes);
        Logger.Log(customer.ID, email, postRes.PostID);
    }
