    public class Customer 
    {
       [PrimaryKey]
       public string id;
       [TextBlob("addressesBlobbed")]
       public List<int> addresses { get; set; }
       public string addressesBlobbed { get; set; } // serialized CoconutWaterBrands
    }
