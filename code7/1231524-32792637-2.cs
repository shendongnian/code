    public class DBFieldMap
    {
        public String fieldName { get; set; }
        public String fieldValue { get; set; }
        // elided
    }
    public class MappedSQLFields : Dictionary<String, DBFieldMap>
    {
        // elided
    }
    public class Audience
    {
        public MappedSQLFields audienceSQLMap { get; set; }
    }
