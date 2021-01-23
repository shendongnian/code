    my_con.Open();
                using (SqlCommand cmd2 = new SqlCommand(" select Medicine_Name from stock where Medicine_Quantity<5", my_con))
                 {
                    SqlDataReader Reader2 = cmd2.ExecuteReader();
                    if (Reader2.HasRows)
                    {
                        StringBuilder str = new StringBuilder();
                        Reader2.Read();
                        while (Reader2.Read())
                        {
    						str.Append(String.Format("{0} medicines quantity is below 5 please order this medicines !\n", Reader2["Medicine_Name"].ToString()));
                        }
    					lblwarn.Text = str.ToString();
    
                    }
                    Reader2.Close();
