     static bool HasFaildSessions()
        {
            int counter = 0;
            bool result = false;
            string connectionString = ConfigurationManager.ConnectionStrings["MySwipe"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select  TOP 3 [Resp_Code],JV_Date from dbo.log_jv_header order by JV_Date desc", connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        
                        while (dataReader.Read())
                        {
                            if (string.Equals(dataReader.GetString(0), "01"))
                                counter++;
                        }
                    }
                }
            }
            if (counter == 3)
                result = true;
            return result;
        }
        static void Main(string[] args)
        {
            if (HasFaildSessions())
            {
                email_send();
                Console.WriteLine("Email Send to Operations Department.");
                Console.ReadLine();
            }
        }
