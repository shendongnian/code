        public class Container
        {
            public List<Country> Country { get; set; }
        }
        public class Country
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
            public string Property4 { get; set; }
            public string Property5 { get; set; }
            public List<dynamic> States { get; set; }
        }
        //public class State
        //{
        //    public string Prop1 { get; set; }
        //    public string Prop2 { get; set; }
        //    public string Prop3 { get; set; }
        //    public string Prop4 { get; set; }
        //}
    var jsonData = JsonConvert.DeserializeObject<Container>(@"
    {
      ""Country"": [
        {
          ""Property1"": ""p1"",
          ""Property2"": ""p2"",
          ""Property3"": ""p3"",
          ""Property4"": ""p4"",
          ""Property5"": ""p5"",
          ""States"": [
            { ""Prop1"": ""p11"", ""Prop2"": ""p12"", ""Prop3"": ""p13"", ""Prop4"": ""p14"" },
            { ""Prop1"": ""p21"", ""Prop2"": ""p22"", ""Prop3"": ""p23"", ""Prop4"": ""p24"", ""Prop5"": ""p25"" }
          ]
        },
        {
          ""Property1"": """",
          ""Property2"": """",
          ""Property3"": """",
          ""Property4"": """",
          ""Property5"": """",
          ""States"": [
            { ""Prop1"": """", ""Prop2"": """", ""Prop3"": """", ""Prop4"": """" },
            { ""Prop1"": """", ""Prop2"": """", ""Prop3"": """", ""Prop4"": """" }
          ]
        }
      ]
    }
                    ");
