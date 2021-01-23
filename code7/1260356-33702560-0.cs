    var service = new ExchangeService
    {
        Credentials = new WebCredentials("somename", "somepass"),
        Url = new Uri("someurl")
    };
    var itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties)
    {
        RequestedBodyType = BodyType.Text
    };
    
    var itemview = new ItemView(1) {PropertySet = itempropertyset};
    var findResults = service.FindItems(WellKnownFolderName.Inbox, itemview);
    var item = findResults.FirstOrDefault();
    item.Load(itempropertyset);
    Console.WriteLine(item.Body);
