    void Main()
    {
        var connectionString = "...";
        var records = new Query(connectionString).SqlQuery<TVChannel>("select top 10 * from TVChannel");
    }
    private class TVChannel
    {
        public string number { get; set; }
        public string title { get; set; }
        public string favoriteChannel { get; set; }
        public string description { get; set; }
        public string packageid { get; set; }
        public string format { get; set; }
    }
    
    public class Query
    {
        private readonly string _connectionString;
        
        public Query(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public List<T> SqlQuery<T>(string query)
        {
            var result = new List<T>();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToArray();
                        var properties = typeof(T).GetProperties();
                        
                        while (reader.Read())
                        {
                            var data = new object[reader.FieldCount];
                            reader.GetValues(data);
                            
                            var instance = (T)Activator.CreateInstance(typeof(T));
    
                            for (var i = 0; i < data.Length; ++i)
                            {
                                if (data[i] == DBNull.Value)
                                {
                                    data[i] = null;
                                }
                
                                var property = properties.SingleOrDefault(x => x.Name.Equals(columns[i], StringComparison.InvariantCultureIgnoreCase));
                
                                if (property != null)
                                {
                                    property.SetValue(instance, Convert.ChangeType(data[i], property.PropertyType));
                                }
                            }
                            result.Add(instance);
                        }
                    }
                }
            }
            return result;
        }
    }
