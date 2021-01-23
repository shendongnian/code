    public enum ComponentType
    {
        First,
        Second,
        Third
    }
    public class Info
    {
        public int Id { get; set; }
        public ComponentType InfoComponentType { get; set; }
        public static void SaveList(List<Info> infoList)
        {
            string ConnectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                foreach (Info info in infoList)
                {
                    string sql = @"INSERT INTO [Info] ([InfoComponentType]) 
                                   VALUES (@InfoComponentType);
                                   SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    int id = conn.Query<int>(sql, new
                    {
                        InfoComponentType = info.InfoComponentType.ToString()
                    }).Single();
                    info.Id = id;
                }
                conn.Close();
            }
        }
    }
