            float eurvalue;
            string connectionString = @"Data Source=C:\Users\FluksikartoN\Documents\BFDB.sdf;Password=Corocoro93!";
            string sql = "SELECT TOP 1 EUR FROM AvailableMoney";
            using (SqlCeConnection conn = new SqlCeConnection(connectionString))
            {
                conn.Open();
                using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            eurvalue = reader.GetFloat(0);
                        }
                    }
                }
            }
            label2.Text = eurvalue.ToString();
