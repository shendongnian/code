                using (SqlConnection con = new SqlConnection("YourConnectioString"))
                {
                    using (SqlDataAdapter da2 = new SqlDataAdapter { SelectCommand = new SqlCommand("select * from tbl_Forms where Module_ID = @Module_ID ", con) })
                    {
                        // as your using index as the parameter,,
                        da2.SelectCommand.Parameters.AddWithValue("@Module_ID", ListView1.SelectedIndex);
                        // or if your trying to pass parameter Module_ID from ListView1 DataKey ,, you can use SelectedDataKey
                        //da2.SelectCommand.Parameters.AddWithValue("@Module_ID", ListView1.SelectedDataKey);
                        using (DataTable dt2 = new DataTable())
                        {
                            con.Open();
                            da2.Fill(dt2);
                            ListView2.DataSource = dt2;
                            ListView2.DataBind();
                        }
                    }
                }
