    public class BeerSource
    {
        [Newtonsoft.Json.JsonProperty( "name" )]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty( "brewery" )]
        public string Brewery { get; set; }
        [Newtonsoft.Json.JsonProperty( "address" )]
        public string Address { get; set; }
    }
    public class BrewerySource
    {
        [Newtonsoft.Json.JsonProperty( "name" )]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty( "date" )]
        public string Date { get; set; }
        [Newtonsoft.Json.JsonProperty( "city" )]
        public string City { get; set; }
    }
