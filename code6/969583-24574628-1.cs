    public class APPS : RepositoryEntryBase, IRepositoryEntry
    {
        public int APP_ID { get; set; }
        public string AUTH_KEY { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public int IS_CLIENT_CUSTOM_APP { get; set; }
        public APPS() : base() {
            primaryKeys.Add("APP_ID");
        }
        public APPS(PlexQueryResultTuple plexTuple) : base(plexTuple) { }
    }
    public class RepositoryEntryBase
    {
        public static RepositoryEntryBase FromPlexQueryResultTuple( RepositoryEntryBase reb, PlexQueryResultTuple plexTuple)
        {
            if (plexTuple.parent == null)
                throw new NotSupportedException("This Operation is Not supported by this PlexTuple.");
            Type type = reb.GetType();
            var pInfo = type.GetProperties();
            PlexQueryResult result = plexTuple.parent;
            foreach (var p in pInfo)
            {
                int index = result.Tuples.IndexOf(plexTuple);
                if (result[p.Name, index] == null)
                    continue;
               
                var conversationType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                object value = Convert.ChangeType(result[p.Name, index], (result[p.Name, index] != null)?conversationType: p.PropertyType);
                p.SetValue(reb, value);
            }
            return reb;
        }
        protected IList<String> primaryKeys;
        public RepositoryEntryBase() 
        {
            primaryKeys = new List<String>();
        }
        public RepositoryEntryBase(PlexQueryResultTuple plexTuple) : this()
        {
            FromPlexQueryResultTuple(this, plexTuple);
        }
        public IList<String> GetPrimaryKeys()
        {
            return primaryKeys;
        }
    }
