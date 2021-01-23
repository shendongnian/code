    public class DBFieldMap
    {
        public String fieldName { get; set; }
        public String fieldValue { get; set; }
        // elided
    }
    public class MappedSQLFields : Dictionary<String, DBFieldMap> { ... }
    public class Audience
    {
        public MappedSQLFields audienceSQLMap { get; set; }
    }
