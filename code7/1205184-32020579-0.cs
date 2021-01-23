    public class ModelledDataColumns
    {
        public string Property1 { get; set; }
        public string Property50 { get; set; }
        public string Property109 { get; set; }
    }
    const string sqlCommand = "SELECT Property1, Property50, Property109 FROM YourTable WHERE Id = @Id";
    IEnumerable<ModelledDataColumns> collection = connection.Query<ModelledDataColumns>(sqlCommand", new { Id = 5 }).ToList();
