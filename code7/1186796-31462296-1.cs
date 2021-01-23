    public class Row
    {
        public int ID { get; set; }
        public bool ischecked { get; set; }
    
    }
    List<Row> list = JsonConvert.DeserializeObject<List<Row>>(stringofjson);
