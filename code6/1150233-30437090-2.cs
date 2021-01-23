       public enum DbType
        {
            UNSUPPORTED = 0,
            MYSQL = 1,
            ORACLE = 2,
            MSSQL = 3
        }
        static void Main(string[] args)
        {
            Console.WriteLine("DBType: {0}", GetDbType(new OdbcConnection("DSN=mysql1")));
            Console.Read();
        }
        public static DbType GetDbType(OdbcConnection cn)
        {
            DbType t = DbType.UNSUPPORTED;
                try
                {
                    cn.Open();
                    var cmd = cn.CreateCommand();
                    string outstring = "";
                    cmd.CommandText = "SELECT @@version, @@version_comment FROM dual";
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            outstring = String.Format("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                    catch (Exception)
                    {
                        cmd = cn.CreateCommand();
                        cmd.CommandText = "SELECT @@version";
                        try
                        {
                            var reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                reader.Read();
                                outstring = String.Format("{0}", reader.GetString(0));
                            }
                        }
                        catch (Exception)
                        {
                            cmd = cn.CreateCommand();
                            cmd.CommandText = "SELECT * FROM v$version";
                            try
                            {
                                var reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    outstring = String.Format("{0}", reader.GetString(0));
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    outstring = outstring.ToUpper();
                    if (outstring.Contains("MYSQL"))
                    {
                        t = DbType.MYSQL;
                    }
                    else if (outstring.Contains("ORACLE"))
                    {
                        t = DbType.ORACLE;
                    }
                    else if (outstring.Contains("SQL SERVER"))
                    {
                        t = DbType.MSSQL;
                    }
                  
                }
                catch (Exception E)
                {
                  
                }
            return t;
        }
