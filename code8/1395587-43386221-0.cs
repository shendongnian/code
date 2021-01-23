     private const string Password = "1234";
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var conn = new SqliteConnection(@"Data Source=test.db;");
                conn.Open();
    
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = $"PRAGMA key = '{Password}';";
                    command.ExecuteNonQuery();
                }
                optionsBuilder.UseSqlite(conn);
            }
