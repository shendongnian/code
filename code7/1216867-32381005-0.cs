          string SQLQuery = "INSERT INTO salesTB (Date,Time,Name,Quantity,Cost)" +
                                "VALUES (@date, @time, @name, @quantity, @cost)";
            using (SqlConnection DBConn = new SqlConnection(cs.ToString()))
            {
                using (SqlCommand sqlCmd = new SqlCommand(SQLQuery, DBConn))
                {
                    sqlCmd.Parameters.Add("@date", SqlDbType.Text);
                    sqlCmd.Parameters["@date"].Value = date.Text;
                    sqlCmd.Parameters.Add("@time", SqlDbType.Text);
                    sqlCmd.Parameters["@time"].Value = time.Text;
                    sqlCmd.Parameters.Add("@name", SqlDbType.Text);
                    sqlCmd.Parameters["@name"].Value = txtName.Text;
                    sqlCmd.Parameters.Add("@quantity", SqlDbType.Int);
                    sqlCmd.Parameters["@quantity"].Value = listBox1.Items.Count;
                    sqlCmd.Parameters.Add("@cost", SqlDbType.Text);
                    sqlCmd.Parameters["@cost"].Value = txtCost.Text
                    DBConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    DBConn.Close();
                }
            }
