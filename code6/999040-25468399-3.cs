	private void button6_Click(object sender, EventArgs e)
	{
		string copyPath = @"C:\user\elec\copy";
		if (!System.IO.Directory.Exists(copyPath))
			System.IO.Directory.CreateDirectory(copyPath);
		for (int i = 0; i < dataGridView1.Rows.Count; i++)
		{
			if (dataGridView1.Rows[i].Cells[0].Value != null && 
				!String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString()))
			{
				string filePath = dataGridView1.Rows[i].Cells[0].Value.ToString();
				if (System.IO.File.Exists(filePath))
				{					
					string fileName = System.IO.Path.GetFileName(filePath);
					string newpath = System.IO.Path.Combine(copyPath, fileName);
					System.IO.File.Copy(filePath, newpath, true);
                    dataGridView1.Rows[i].Cells[1].Value = newpath;
                    try
                    { 
                        Using (SqlConnection con = new SqlConnection(@"Data Source=STACY121\SQLEXPRESS;Initial Catalog=cndb;Integrated Security=True"))
                        {
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "update cncinfo set Column1=@Column1,Column2=@Column2 Where id=@id";
                            cmd.Parameters.Add("@Column1",SqlDbType.VarChar).Value =filePath;
                            cmd.Parameters.Add("@Column2",SqlDbType.VarChar).Value =newpath;
                            //you must have the id value in datagridview to update the specific record.
                            cmd.Parameters.Add("@id",SqlDbType.Int).Value =Convert.ToInt32(dataGridView1.Rows[i].Cells["id"].Value);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                     }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    } 
				}
				dataGridView1.Rows[i].Cells[0].Value = string.Empty;
			}
		}
	}
