    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""bigNumber"": 12093812947635091350945141034598534526723049126743245
            }";
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new BigIntegerConverter() }
            };
            Foo foo = JsonConvert.DeserializeObject<Foo>(json);
            Console.WriteLine(foo.BigNumber.ToString());
        }
    }
    class Foo
    {
        public Org.BouncyCastle.Math.BigInteger BigNumber { get; set; }
    }
