            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.Credentials = new WebCredentials("user_with_access@example.com", "PASSWORD");
            service.TraceEnabled = true;
            service.TraceFlags = TraceFlags.All;
            service.AutodiscoverUrl("user_with_access@example.com", RedirectionUrlValidationCallback);
           
            var userMailbox = new Mailbox("target_user@example.com");
            var folderId = new FolderId(WellKnownFolderName.Inbox, userMailbox);
            var itemView = new ItemView(20);   // page size
            var userItems = service.FindItems(folderId, itemView);
            foreach (var item in userItems)
            {
                // do something with item (nb: it might not be a message)
            }
     Above code need user's credential .If you don't have permission to access target user's mailbox ,above code will threw an error like " The process failed to get the correct properties" .
