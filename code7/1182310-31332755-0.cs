    XElement doc = null;
    doc = new XElement("root");
    doc.Add(new XElement("Email",
            new XElement("FromAddress", content.FromAddress),
            new XElement("EmailReceivedOn", content.receivedOnemail),
            new XElement("Subject", content.subject),
            new XElement("Body", content.body)));
     var email=doc.Element("Email"); // get email element from root Element
     foreach (var attachment in content.attachments)
        {
          //Add attachemnt information to email element.
          email.Add(new XElement("attachmentname"), attachment.Filename),
          email.Add(new XElement(("attachmentpath"), attachment.Filepath)        
        }
