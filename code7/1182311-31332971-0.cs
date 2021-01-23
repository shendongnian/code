	var doc =
		new XElement("root",
			new XElement("Email",
        		new XElement("FromAddress", content.FromAddress),
       			new XElement("EmailReceivedOn", content.receivedOnemail),
        		new XElement("Subject", content.subject),
        		new XElement("Body", content.body),
				content.attachments.Select(attachment =>
					new XElement("attachment",
						new XElement("attachmentname", attachment.Filename),
						new XElement("attachmentpath", attachment.Filepath)))));
