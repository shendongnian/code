        public static void something()
        {
            string stmt = "select * from GazeTable where id = " + 1 + " ;";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(stmt, conn);
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}", ((SqlDataReader)reader).GetTimeSpan(3).ToString(@"dd\.hh\:mm\:ss\:ff"));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
            conn.Close();
        }
