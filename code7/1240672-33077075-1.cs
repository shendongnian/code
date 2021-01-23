    public class YourModel
    {
        [JsonConverter(typeof(CustomConverter<BigInteger>))]
        public BigInteger YourProperty{ get; set; }
    }
