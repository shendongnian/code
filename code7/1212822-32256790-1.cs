    public ActionResult DownloadEmail()
    {
        var message = new MailMessage();
        message.From = new MailAddress("from@example.com");
        message.To.Add("someone@example.com");
        message.Subject = "This is the subject";
        message.Body = "This is the body";
        using (var client = new SmtpClient())
        {
            var id = Guid.NewGuid();
            var tempFolder = Path.Combine(Path.GetTempPath(), Assembly.GetExecutingAssembly().GetName().Name);
            tempFolder = Path.Combine(tempFolder, "MailMessageToEMLTemp");
            // create a temp folder to hold just this .eml file so that we can find it easily.
            tempFolder = Path.Combine(tempFolder, id.ToString());
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.PickupDirectoryLocation = tempFolder;
            client.Send(message);
            // tempFolder should contain 1 eml file
            var filePath = Directory.GetFiles(tempFolder).Single();
            // stream out the contents - don't need to dispose because File() does it for you
            var fs = new FileStream(filePath, FileMode.Open);
            return File(fs, "application/vnd.ms-outlook", "email.eml");
        }
    }
