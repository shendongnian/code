    Redemption.RDOSession rSession = new Redemption.RDOSession();
    rSession.MAPIOBJECT = mailItem.Application.Session.MAPIOBJECT;
    Redemption.RDOMail rMail= rSession.GetRDOFolderFromOutlookObject(mailItem)
    foreach (Redemption.RDOAttachment attach in rMail.Attachments)
    {
      if ((attach.Type == Redemption.rdoAttachmentType.olByValue) && (!attach.Hidden))
      {
         attach.SaveAsFile(path);
      }
    }
    next
