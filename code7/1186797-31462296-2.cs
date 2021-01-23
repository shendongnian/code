    public class RowJson
    {
       [JsonProperty("Rows")]
       public Row Row { get; set; }
    }
    public class Row
    {
        public int ID { get; set; }
        public bool ischecked { get; set; }
    
    }
    List<RowJson> list = JsonConvert.DeserializeObject<List<RowJson>>(stringofjson);
 
