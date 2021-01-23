    public class Cust
    {
        [JsonProperty(PropertyName = nameof(Cust) + "." + nameof(Cust.Name))]
        public string Name { get; set; }
        [JsonProperty(PropertyName = nameof(Cust) + "." + nameof(Cust.CNIC))]
        public string CNIC { get; set; }
    }
