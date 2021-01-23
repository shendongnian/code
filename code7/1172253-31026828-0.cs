     public class MyModel
     {
          [JsonProperty(PropertyName = "Prop1")]
          public string Property1 { get; set; }
          [JsonProperty(PropertyName = "Prop2")]
          public string Property2 { get; set; }
     }
     public class Wrapper{
          [JsonProperty(PropertyName = "MyModel")]
        public MyModel myModel{get;set;}
     }
