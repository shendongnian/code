    public class CheckPoint
    {
        public string CheckPoint1 { get; set; }
        public string CheckPoint2 { get; set; }
        public string CheckPoint3 { get; set; }
        public string CheckPoint4 { get; set; }
        public string CheckPoint5 { get; set; }
    }
    public class MyCheckpoints
    {
        public List<CheckPoint> GetCheckPoins()
        {
            List<CheckPoint> checkpoints = new List<CheckPoint>();
            string connectionString = ConfigurationManager.ConnectionStrings["lusdMembership"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT chk1, chk2, chk3, chk4, chk5 FROM checkpoints", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CheckPoint c = new CheckPoint
                        {
                            CheckPoint1 = reader["chk1"].ToString(),
                            CheckPoint2 = reader["chk2"].ToString(),
                            CheckPoint3 = reader["chk3"].ToString(),
                            CheckPoint4 = reader["chk4"].ToString(),
                            CheckPoint5 = reader["chk5"].ToString(),
                        };
                        checkpoints.Add(c);
                    }
                    connection.Close();
                }
            }
            return checkpoints;
        }
    }
