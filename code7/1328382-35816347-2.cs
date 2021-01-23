      public class CarchingPointClass
      {
       public string _id { get; set; }
       public double price { get; set; }
       public string type { get; set; }
       public string model { get; set; }
       public string modelID { get; set; }
       public double lat { get; set; }
       [JsonProperty("long")]
       public double lng { get; set; }
       public string address { get; set; }
       public int __v { get; set; }
       public string modified_at { get; set; }
       public string created_at { get; set; }
     }
