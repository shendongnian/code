    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
    service.Credentials = new WebCredentials("username", "Password");
    service.AutodiscoverUrl(Ownerusername, RedirectionUrlValidationCallback);
	
	//Make sure you include the properties you are looking for in EmailMessageSchema
	PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.Subject, EmailMessageSchema.ToRecipients);
	
	//Add your Ids stored in the database here
	var itemIds = new List<ItemId>();
	foreach(var MailIds in db.Mails.select(a=>a.Ids))
	{
		itemIds.add(new ItemId(MailIds));
	}
	
	//Send one request to EWS and get all mails by Id
	ServiceResponseCollection<GetItemResponse> response = service.BindToItems(itemIds, propSet);
	
	//Get the emails
	foreach (GetItemResponse getItemResponse in response)
	{
		Item item = getItemResponse.Item;
		EmailMessage message = (EmailMessage)item;
	}
