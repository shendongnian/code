        public static void send(string subject, string body, string from, string to, List<string> attachments = null)
        {
            using (MailMessage message = new MailMessage(new MailAddress(from), new MailAddress(to)))
            {
                message.Subject = subject;
                message.Body = body;
                if (attachments != null && attachments.Count > 0)
                {
                    foreach (string s in attachments)
                    {                        
                        if (s != null)
                        {
                            /* this code fixes the error where the attached file is 
                             * prepended with the path of the file */
                            Attachment attachment = new Attachment(s, MediaTypeNames.Application.Octet);
                            ContentDisposition disposition = attachment.ContentDisposition;
                            disposition.CreationDate = File.GetCreationTime(s);
                            disposition.ModificationDate = File.GetLastWriteTime(s);
                            disposition.ReadDate = File.GetLastAccessTime(s);
                            disposition.FileName = Path.GetFileName(s);
                            disposition.Size = new FileInfo(s).Length;
                            disposition.DispositionType = DispositionTypeNames.Attachment;
                            message.Attachments.Add(attachment);
                        }
                    }
                }
                using (SmtpClient client = new SmtpClient())
                {
                    client.Send(message);
                }
            }
        }
