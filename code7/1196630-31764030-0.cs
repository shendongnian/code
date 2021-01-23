    string email = "<user>@<host>";
    string user = "<user>";
    string password = "<password>";
    string serviceUrl = "https://<url>/ews/exchange.asmx";
    
    Mailbox mailbox = new Mailbox(email);
    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    service.Credentials = new WebCredentials(user, password);
    service.Url = new Uri(serviceUrl);
    
    FolderId inbox = new FolderId(WellKnownFolderName.Inbox, mailbox);
    SearchFilter searchFilter = new SearchFilter.IsGreaterThan(ItemSchema.DateTimeSent, DateTime.Now);
    ItemView view = new ItemView(10); // take 10 items
    view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
    FindItemsResults<Item> result = service.FindItems(inbox, searchFilter, view);
