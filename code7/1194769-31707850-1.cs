     using (var conn = new SqlConnection())
            {
                foreach (var item in listView1.Items)
                {
                    string firstValue = item.SubItem.First();
                    string secondValue = item.Subitem.Last();
                    String insertSQL = @"INSERT INTO SALES_TABLE(pay_type, pay_amount) 
                                    VALUES (@val1 , @val2)";
                    SqlCommand cmd = new SqlCommand(insertSQL, conn);
                    cmd.Parameters.AddWithValue("@val1",firstValue);
                    cmd.Parameters.AddWithValue("@val2", secondValue);
                    cmd.ExecuteNonQuery();
                } 
            }
