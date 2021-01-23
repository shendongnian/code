            private void GetData()
            {
                SqlConnection connection = new SqlConnection("Data Source = localhost\\SQLEXPRESS;Initial Catalog = MejOnlineManagementDB00;Integrated Security=True;");
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(@"SELECT price
                                                    FROM Products3
                                                    WHERE productName='" + DropDownList1.SelectedItem.Value.ToString() + "'", connection);
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while (rdr.Read())
                    {
                        lblPrice.Text = rdr.GetValue(0).ToString(); //  if price is  string use GetString(0))
                    }
                }
                connection.Close();
            }
