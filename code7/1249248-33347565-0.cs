    conn.Open();
                string sql1 = "delete from Orders where OrderID='" + lstOrders.SelectedValue + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                string sql = "Delete from Car where CarID='" + lstCar.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
