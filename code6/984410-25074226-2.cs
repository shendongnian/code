            String mailboxToAccess = "user@domain.onmicrosoft.com";
            ExchangeService _service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            _service.Credentials = new WebCredentials("upn@domain.onmicrosoft.com", "password");
            _service.AutodiscoverUrl(mailboxToAccess, redirect => true);
           // _service.Url = new Uri("https://***/EWS/Exchange.asmx");
            ItemView iv = new ItemView(1000);
            FolderId ContactsFolderId = new FolderId(WellKnownFolderName.Contacts,mailboxToAccess);
            FindItemsResults<Item> fiResults;
            do
            {
                fiResults = _service.FindItems(ContactsFolderId, iv);
                foreach (Item itItem in fiResults.Items)
                {
                    if (itItem is Contact)
                    {
                        Contact ContactItem = (Contact)itItem;
                        Console.WriteLine(ContactItem.Subject);
                    }
                }
                iv.Offset += fiResults.Items.Count;
            } while (fiResults.MoreAvailable);
