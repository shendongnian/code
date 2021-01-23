        public void ExecuteSqlFilesInDirectory(string path, string connectionString)
        {
            var directory = new DirectoryInfo(path);
            var files = directory.GetFiles("*.sql");
            if (!files.Any()) return;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var file in files)
                {
                    var sql = File.ReadAllText(file.FullName);
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
