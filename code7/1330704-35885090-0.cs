    public class JsonNet_35883686
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class CreditCard
        {
            [JsonProperty]
            public int Id { get; set; }
            public int CustomerId { get; set; }
        }
        public static void Run()
        {
            var cc = new CreditCard {Id = 1, CustomerId = 123};
            var json = JsonConvert.SerializeObject(cc);
            Console.WriteLine(json);
            cc = null;
            json = JsonConvert.SerializeObject(cc);
            Console.WriteLine(json);
        }
    }
