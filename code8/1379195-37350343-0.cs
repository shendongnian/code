    namespace Namespace.Email
    {
        public class EmailLinker
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
        
            public EmailLinker()
            {
                service.Credentials = new NetworkCredential("username", "password", "domain");
                service.AutodiscoverUrl("email@email.com");
            }
            public void linkEmails()
            {
                FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(128));
                if (findResults.TotalCount > 0)
                {
                    ServiceResponseCollection<GetItemResponse> items = service.BindToItems(findResults.Select(item => item.Id), new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.From, EmailMessageSchema.ToRecipients));
                    foreach (GetItemResponse i in items)
                    {
                        MailItem m = new MailItem();
                        Item it = i.Item;
                        m.From = ((Microsoft.Exchange.WebServices.Data.EmailAddress)it[EmailMessageSchema.From]).Address;
                        m.Recipients = ((Microsoft.Exchange.WebServices.Data.EmailAddressCollection)it[EmailMessageSchema.ToRecipients]).Select(r => r.Address).ToArray();
                        m.Subject = it.Subject;
                        m.Body = it.Body.Text;
                        m.Recieved = it.DateTimeReceived;
                        m.attachments = it.Attachments;
                        foreach (Attachment a in m.attachments)
                             this.uploadAttachments(a);
                        i.Item.Delete(DeleteMode.HardDelete);
                    }
                }
            }
            private void uploadAttachments(Attachment a)
            {
                ContentFile cf = new ContentFile();
                cf.Name = a.Name;
                cf.Size = a.Size;
                cf.ContentType = MimeTypeMap.GetMimeType(Path.GetExtension(a.Name).Replace(".",""));
                FileAttachment fa = (FileAttachment)a;
                fa.Load();
                cf.Data = fa.Content;
                cf.DateAdded = DateTime.Now;
                cf.save();
            }
            public class MailItem
            {
                public int id;
                public string From;
                public string[] Recipients;
                public string Subject;
                public string Body;
                public DateTime Recieved;
                public string RecievedString
                {
                    get
                    {
                        return Recieved.ToShortDateString() + " " + Recieved.ToShortTimeString();
                    }
                }
                public AttachmentCollection attachments;
            }
        }
    }
    
