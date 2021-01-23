    static int GetOrderQuantity()
            {
                int quantity = 0;
                string sql = "select sum(Quantity) from [dbo].Orderdetails ";
                using (SqlConnection conn = new SqlConnection("Your connection string"))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    try
                    {
                        conn.Open();
                        quantity = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        //Handle exception
                    }
                }
                return quantity;
            }
