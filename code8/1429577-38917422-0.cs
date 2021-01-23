    string query = "Select * From Contacts where [Phone No] = " + textBox00.Text + "";
                    using (OleDbConnection conn = new OleDbConnection(connStr))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                        {
                            conn.Open();
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            if (ds != null && ds.tables[0].rows.count>0)
                            {                                
                                label128.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                                setaluefortext00001 = ds.Tables[0].Rows[0]["Phone No"].ToString();
                                setaluefortext00002 = ds.Tables[0].Rows[0]["Address"].ToString();
                                   
                            }
                            else
                            {                                
                                
                                OleDbCommand command1 = new OleDbCommand();
                                command1.Connection = conn ;
                                command1.CommandText = "insert into Contacts ([Name],[Phone No],[Address])values('" + textBox.Text + "'," + textBox00.Text + ",'" + textBox000.Text + "');";
                                command1.ExecuteNonQuery();                                
                                label128.Text = textBox.Text;
                                setaluefortext00002 = textBox00.Text;
                                setaluefortext00003 = textBox000.Text;
                            }
                            conn.Close();
