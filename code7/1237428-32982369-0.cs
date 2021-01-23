    public UseExchangeServer(string mailBox)
    {
        _service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
        _service.UseDefaultCredentials = true;
        _service.AutodiscoverUrl(mailBox);
    }
     public FindItemsResults<Item> GetLastItems(int numberOfItems,string mailBox)
    {
        FolderId FolderToAccess = new FolderId(WellKnownFolderName.Inbox,mailBox);
        return _service.FindItems(FolderToAccess, new ItemView(numberOfItems));
    }
    public IEnumerable<EmailMessage> LoadMessages(int numberOfMessages)
    {
        var findResults = GetLastItems(numberOfMessages);
        foreach (var item in findResults.Items)
        {
            var message = EmailMessage.Bind(_service, item.Id, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments));
            message.Load();
            yield return message;
        }
    }
