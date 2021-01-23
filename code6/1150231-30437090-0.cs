        static void Main(string[] args)
        {
            using (OdbcConnection cn = new OdbcConnection("DSN=mysql1"))
            {
                try
                {
                    cn.Open();
                    var cmd = cn.CreateCommand();
                    cmd.CommandText = "SELECT @@version, @@version_comment FROM dual";
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Console.WriteLine("Got status: {0} {1}" , reader.GetString(0), reader.GetString(1));
                        //Got status: 5.6.11 MySQL Community Server (GPL)
                    }
                    Console.WriteLine("Connected via {0}",cn.Driver);
                }
                catch (Exception E)
                {
                    Console.WriteLine("Database error: {0}",E.Message);
                }
            }
            Console.Read();
        }
