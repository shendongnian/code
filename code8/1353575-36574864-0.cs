    foreach (var mailItem in emails)
    {
        string email = mailItem.Trim();
        templateData = mailEntitiyData.HtmlContent;             
        templateData = templateData.Replace("##FULL_NAME##", customer.Name + " " + customer.Surname);
        var postRes = mh.SendMail(subject, templateData , email, postType, null, null, bytes);
        Logger.Log(customer.ID, email, postRes.PostID);
    }
