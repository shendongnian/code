    // POST api/<controller>
        public void Post([FromBody]Customer customer)
        {
            var token = customer.Token;
            // mailsID to retrieve from Exchange
            // IDs come from Office.context.mailbox.item.itemId
            // var mailsID = JsonConvert.DeserializeObject<List<string>>(customer.Id);
            
            
            var exService = new ExchangeService
            {
                Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx"),
                Credentials = new OAuthCredentials(token),
                // WebCredentials works but I don't want the user to enter that
                // Credentials = new WebCredentials("mymail@onmicrosoft.com", "mypass");
            };
            var itemId = new ItemId(customer.Id);
            // Try to get the mail from Exchange Online
            var email = EmailMessage.Bind(exService, itemId);
            string subject = email.Subject; 
            // ... Rest of the code
        }
    public class Customer
    {
        public string Token { get; set; }
        public string Id { get; set; }
    }
