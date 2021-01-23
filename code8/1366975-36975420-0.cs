    using SQLitePCL;
     using (var conn = new SQLiteConnection("Storage.db"))
                {
                    string sql = @"CREATE TABLE IF NOT EXISTS People (
                                                ID INTEGER NOT NULL PRIMARY KEY,
                                                FirstName NVARCHAR(50),
                                                LastName NVARCHUAR(50));";
                    using (var statement = conn.Prepare(sql))
                    {
                        statement.Step();
                    }
                }
