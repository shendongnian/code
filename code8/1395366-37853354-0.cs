    Mailbox mb = new Mailbox("processmailbox@domain.com");
    FolderId fid = new FolderId(WellKnownFolderName.Inbox, mb);
    ItemView view = new ItemView(100);
    
    //use your service to get 100 mails from the mailbox
    var findResults = service.FindItems(fid, view);
    
    foreach (var item in findResults.Items)
    {
    	var message = EmailMessage.Bind(service, item.Id, new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.Attachments));
    }
