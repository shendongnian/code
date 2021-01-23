    public List<string> GetUploadPaths(IEnumerable<HttpPostedFileBase> files)
    {
        var paths = new List<string>();
        foreach (var file in files)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                paths.Add(path);
            }
        }
        return paths;
    }
    public MailMessage ConstructMailMessage(EmailFormModel model)
    {
         var message = new MailMessage();
         var body = "<p><b>Email From:</b> {0} ({1})</p><p><b>Subject:</b> {2} </p><p><b>Software Description:</b></p><p>{4}</p><p><b>Message:</b></p><p>{3}</p>";
         message.To.Add(new MailAddress("email@mydomain.com"));  // replace with valid value 
         message.From = new MailAddress("email@randomdomain.com");  // replace with valid value
         message.Subject = "(Inquire for SELLING)";
         message.Body = string.Format(body, model.FromName, model.FromEmail, model.FromSubject, model.Message, model.Desc);
         message.IsBodyHtml = true;
         return message;
    }
    public void AppendAttachments(List<string> paths, AttachmentCollection attachments)
    {
        foreach (var path in paths)
        {
            var fileInfo = new FileInfo(path);
            var memoryStream = new MemoryStream();
            using (var stream = fileInfo.OpenRead())
            {
                stream.CopyTo(memoryStream);
            }
            memoryStream.Position = 0;
            string fileName = fileInfo.Name;
            attachments.Add(new Attachment(memoryStream, fileName));
        }
    }
