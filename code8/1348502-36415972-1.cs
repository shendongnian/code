    String MailboxToAccess = "user@domain.com";
    ExchangeService service = new Microsoft.Exchange.WebServices.Data.ExchangeService(ExchangeVersion.Exchange2010_SP1);
    SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead,false);        
    
    service.Credentials = new NetworkCredential("user@domain.com", "password");
    service.AutodiscoverUrl(MailboxToAccess, adAutoDiscoCallBack);
    FolderId FolderToAccess = new FolderId(WellKnownFolderName.Inbox, MailboxToAccess);
    ItemView ivItemView = new ItemView(10);
    FindItemsResults<Item> FindItemResults = service.FindItems(FolderToAccess, sfSearchFilter, ivItemView);
    PropertySet ItemPropertySet = new PropertySet(BasePropertySet.IdOnly);
    ItemPropertySet.Add(ItemSchema.Body);
    ItemPropertySet.RequestedBodyType = BodyType.Text;
    if (FindItemResults.Items.Count > 0)
    {
        service.LoadPropertiesForItems(FindItemResults.Items, ItemPropertySet);
    }
    foreach (Item item in FindItemResults.Items)
    {
        Console.WriteLine(item.Body.Text);
    }
	
	internal static bool adAutoDiscoCallBack(string redirectionUrl)
    {
        // The default for the validation callback is to reject the URL.
        bool result = false;
        Uri redirectionUri = new Uri(redirectionUrl);
        // Validate the contents of the redirection URL. In this simple validation
        // callback, the redirection URL is considered valid if it is using HTTPS
        // to encrypt the authentication credentials. 
        if (redirectionUri.Scheme == "https")
        {
            result = true;
        }
        return result;
    }
