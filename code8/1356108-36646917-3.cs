        [JsonProperty("customer")]
        [JsonConverter(typeof(FakeArrayToNullConverter<Customer>))]
        public Customer Customers { get; set; }
        
        [JsonProperty("application_address")]
        [JsonConverter(typeof(FakeArrayToNullConverter<ApplicationAddress>))]
        public ApplicationAddress ApplicationAddressList { get; set; }
