    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
    service.Credentials = new WebCredentials("username", "Password");
    service.AutodiscoverUrl(Ownerusername, RedirectionUrlValidationCallback);
    //Select which mailbox you want to get mails from
    Mailbox mb = new Mailbox("mail@yourdomain.com");
    //Select which folder in your mailbox you want
    FolderId fid = new FolderId(WellKnownFolderName.Inbox, mb);
    //I recommend you to not fetch all mail at once
    ItemView view = new ItemView(100);
    //Make the request on the EWS api
    FindItemsResults<Item> findResults = service.FindItems(fid, view);
    //Loop through the results
    foreach (var item in findResults.Items)
    {
        EmailMessage message = EmailMessage.Bind(service, item.Id, new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.Attachments));
    }
