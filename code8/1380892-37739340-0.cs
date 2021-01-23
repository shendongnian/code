        public static void Main(string[] args)
        {
                using (SqlConnection connection = new SqlConnection("Server=(localdb)\\v11.0;Database=MyAdventureWorks;Trusted_Connection=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select * from [Person].[Person]", connection);
                    DbDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SchemaOnly);
                    if (reader.CanGetColumnSchema())
                    {
                        var columns = reader.GetColumnSchema();
                        foreach (var column in columns)
                        {
                            Console.Write("ColumName: " + column.ColumnName);
                            Console.Write(", DataTypeName: " + column.DataTypeName);
                            Console.Write(", ColumnSize: " + column.ColumnSize);
                            Console.WriteLine(", IsUnique: " + column.IsUnique);
                        }
                    }
                    else
                        throw new Exception("Connection does not support GetColumnSchema.");
                }
                Console.ReadLine();
        }
