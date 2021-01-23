    public class YourBusinessObjectRequestDto
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        ...
        
        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>()
              {
                { "id", id },
                { "firstName", firstName },
                { "lastName", lastName },
                { "address", address },
                { "postalCode", postalCode },
                { "...", ... }
              };
        }
    }
