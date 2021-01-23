    public class DataStore
    {
        private string _connectionStr;
        public DataStore(string connectionStr)
        {
            this._connectionStr = connectionStr;
        }
        public DataTable ExecuteCommand(string commandText, IDictionary<string,string> parameters)
        {
            using (var connection = new OleDbConnection(this._connectionStr))
            {
                connection.Open();
                using (var cmd = new OleDbCommand(commandText, con))
                {
                    foreach (var pair in parameters)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }
    }
