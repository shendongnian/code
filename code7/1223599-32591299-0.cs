    public class Program
    {
        public void Main(string[] args)
        {
            var json = @"
                {   
                    ""cars"": {
                        ""Ferrari"":[""LaFerrari"",""F40"",""458""],
                        ""Porsche"":[""911"",""959""],
                        ""Lamborghini"":[""Aventador""]
                    }
                }
            ";
            var dataObj = JsonConvert.DeserializeObject<Data>(json);
        }
        public class Data
        {
            public Dictionary<string, List<string>> Cars { get; set; }
        }
    }
