    if (!string.IsNullOrEmpty(sMail.Attachments[i].Name))
                        {
                            if (!sMail.Attachments[i].Name.Contains(".dat"))
                            { 
                               ObjMail.Add(sMail.Attachments[i]);
                            }
                        }
    ObjMail.SendMail();
