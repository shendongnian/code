    private void getImage()
            {
                using (MySqlConnection conn = new MySqlConnection(connectionManager.connectionString))
                {
                    try
                    {
                        conn.Open();
    
                        string query = "SELECT Image FROM student_img WHERE ID =  @ID";
    
                        MySqlCommand cmd = new MySqlCommand(query, conn);
    
                        int id = 10;
                        cmd.Parameters.AddWithValue("@ID", id);
    
                        var da = new MySqlDataAdapter(cmd);
                        var ds = new DataSet();
                        da.Fill(ds, "Image");
                        int count = ds.Tables["Image"].Rows.Count;
    
                        if (count > 0)
                        {
                            var data = (Byte[])(ds.Tables["Image"].Rows[count - 1]["Image"]);
                            var stream = new MemoryStream(data);
                            picLogo.Image = Image.FromStream(stream);
                        }
    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Error!\n" + ex.Message, "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
    
            }
