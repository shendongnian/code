    [DataContract]
    public class Client
    {
        [DataMember]
        public DateTime Created { get; set; }
    
        [DataMember]
        public string CreatedTimeZoneId { get; set; }
    }
    
    public class ClientDto
    {
        private readonly Client _client;
    
        public ClientDto(Client client)
        {
            _client = client;
        }
    
        public DateTimeOffset Created
        {
            get
            {
                //TODO: Should be moved in separate helper method.
                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(_client.CreatedTimeZoneId);
                return new DateTimeOffset(_client.Created, timeZoneInfo.BaseUtcOffset);
            }
        }
    }
