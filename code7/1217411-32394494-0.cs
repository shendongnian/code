    if (!string.IsNullOrEmpty(sMail.Attachments[i].Name))
                    {
                        if (!sMail.Attachments[i].Name.Contains(".dat"))
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            sMail.Attachments[i].ContentStream.CopyTo(ms);
    
                            ObjMail.AddAttachment(ms, sMail.Attachments[i].Name);
                        }
                    }
