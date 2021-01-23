    class ServerResponse
    {
        [JsonProperty("addresses")]
        public List<AddressResponse> Addresses { get; set; }
    }
    class AddressResponse
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("total_received")]
        public long TotalReceived { get; set; }
    }
