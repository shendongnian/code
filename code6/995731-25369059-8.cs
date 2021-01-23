    public class UserRecord
    {
        public string User { get; set; }
        public List<AliasRecord> AliasRecords { get; set; }
    }
    public class AliasRecord
    {
        public string Alias { get; set; }
        public string Number { get; set; }
    }
