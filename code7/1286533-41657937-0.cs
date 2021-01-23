       private double failingGrade;
        public double getFailingGrade()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConnection.Connection()))
            {
                conn.Open();
                using (MySqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "select failing from gradespercentage_tab";
                   return failingGrade = double.Parse(comm.ExecuteScalar().ToString());
                
                }
            }
        }
