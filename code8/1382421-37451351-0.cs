    private static System.Timers.Timer t;
        static void Main(string[] args)
        {
            t = new System.Timers.Timer(new TimeSpan(0,0,0,30).TotalMilliseconds);
            t.Start();
        }
        public static void ExecuteSql()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=SYNCLAPN136;Initial Catalog=Testdata;Integrated Security=True;Connect Timeout=30";
                con.Open();
                string command = "INSERT INTO [Table_1] (xName,yName) VALUES(@x,@y)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.Add("@x", date);
                cmd.Parameters.Add("@y", val);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
