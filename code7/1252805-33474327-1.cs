    using (SqlConnection con =new SqlConnection(/*Your Connection String*/))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.Connection = con;
                            con.Open();
                            sda.SelectCommand = cmd;
                            // This is for test purposes
                            List<int> yourValues = new List<int>() { 1, 2, 3, 4, 5 };
                            //Get values for IN
                            string x = string.Join(",", yourValues.Select(s => String.Format("{0}", s)).ToArray());
                            cmd.CommandText = "SELECT* FROM Order_Header where Status IN(" + x + ")";
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                        }
                        catch
                            (Exception
                                ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                            sda.Dispose();
                            con.Dispose();
                        }
                    }
                }
