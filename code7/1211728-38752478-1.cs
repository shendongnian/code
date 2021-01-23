    // Modified from: https://ruijarimba.wordpress.com/2012/03/25/bulk-insert-dot-net-applications-part1 and
    // https://ruijarimba.wordpress.com/2012/03/18/entity-framework-get-mapped-table-name-from-an-entity/
    internal class BulkInserter
    {
        private readonly ObjectContext objectContext;
        private readonly IDbConnection connection;
        internal BulkInserter(DbContext contextAdapter)
        {
            objectContext = ((IObjectContextAdapter)contextAdapter).ObjectContext;
            connection = contextAdapter.Database.Connection;
        }
        public void Insert<T>(IEnumerable<T> items) where T : class
        {
            EnsureOpenConnection();
            using (var bulkCopy = new SqlBulkCopy((SqlConnection)connection)
            {
                DestinationTableName = GetTableName<T>(),
            })
            {
                foreach (var mapping in GetColumnMappings<T>())
                {
                    bulkCopy.ColumnMappings.Add(mapping);
                }
                bulkCopy.WriteToServer(items.ToDataTable());
            }
        }
        private void EnsureOpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        private string GetTableName<T>() where T : class
        {
            string sql = objectContext.CreateObjectSet<T>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);
            string table = match.Groups["table"].Value;
            return table;
        }
        private IEnumerable<SqlBulkCopyColumnMapping> GetColumnMappings<T>()
        {
            var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
            var entityPropMembers = storageMetadata
                .Where(s => (s.BuiltInTypeKind == BuiltInTypeKind.EntityType))
                .Select(s => (EntityType)s)
                .Where(p => p.Name == typeof(T).Name)
                .Select(p => (IEnumerable<EdmMember>)(p.MetadataProperties["Members"].Value))
                .First();
            var sourceColumns = entityPropMembers.Select(m => (string)m.MetadataProperties["PreferredName"].Value);
            var destinationColumns = entityPropMembers.Select(m => m.Name);
            return Enumerable.Zip(sourceColumns, destinationColumns, (s, d) => new SqlBulkCopyColumnMapping(s, d));
        }
    }
