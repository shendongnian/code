    public class Cart
    {
        public long? cartId { get; set; }
        public string id { get; set; }
        public string quantity { get; set; }
        public CartModifier modifier { get; set; }
    }
    [JsonConverter(typeof(CartModifierSerializer))]
    public class CartModifier
    {
        public CartModifier()
        {
            Values = new Dictionary<string, long>();
        }
        public Dictionary<string, long> Values { get; set; }
    }
