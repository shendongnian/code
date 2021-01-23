     foreach (var folderId in folderIds)
            {
                db.Mails.Add(new Mail
                {
                    From = from,
                    To = to,
                    CC = cc,
                    Attachments = attachments.ToList(),
                    BodyHtml = bodyHtml,
                    BodyPlain = bodyPlain,
                    Subject = subject,
                    Incoming = true,
                    Priority = receivedMail.Priority,
                    ReceivedOn = DateTime.UtcNow,
                    Status = MailStatus.Open,
                    Read = false,
                    Folder = db.Folders.Find(folderId)
                });
            }
