    [HttpPost]
    public List<InternetMessageHeader> GetMailHeader(MailRequest request) {
        ExchangeService service = new ExchangeService();
        service.Credentials = new OAuthCredentials(request.AuthenticationToken);
        service.Url = new Uri(request.EwsUrl);
    
        ItemId id = new ItemId(request.ItemId);
        EmailMessage email = EmailMessage.Bind(service, id, new PropertySet(ItemSchema.InternetMessageHeaders));
    
        if (email.InternetMessageHeaders == null)
            return null;
    
        return email.InternetMessageHeaders.ToList();
    }
