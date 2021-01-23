    public static void Bar()
        {
            Task.Run(async () =>
            {
                using (var conn = new SqlConnection("Server=.;Database=Test;Trusted_Connection=True;"))
                {
                    await conn.OpenAsync();
                    var trans = conn.BeginTransaction();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "CREATE TABLE #muMapping ( mu_id INT NOT NULL PRIMARY KEY, facility NVARCHAR(100) NOT NULL, team NVARCHAR(100) NOT NULL );";
                        cmd.Transaction = trans;
                        await cmd.ExecuteNonQueryAsync();
                    }
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO #muMapping VALUES (@mu, @facility, @team);";
                        cmd.Parameters.Add("@mu", SqlDbType.Int);
                        cmd.Parameters.Add("@facility", SqlDbType.NVarChar, 100);
                        cmd.Parameters.Add("@team", SqlDbType.NVarChar, 100);
                        cmd.Transaction = trans;
                        cmd.Prepare();
                        foreach (var i in new[] {1, 2, 3})
                        {
                            try
                            {
                                cmd.Parameters[0].Value = i;
                                cmd.Parameters[1].Value = "f";
                                cmd.Parameters[2].Value = "t";
                                cmd.ExecuteNonQuery(); //Error thrown here
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                throw;
                            }
                            
                        }
                    }
                }
            }).Wait();
            //Other statements
        }
