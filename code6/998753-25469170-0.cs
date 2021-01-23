     private void button6_Click(object sender, EventArgs e)
    {
        string copyPath = @"C:\user\elec\copy";
     if (!System.IO.Directory.Exists(copyPath))
    System.IO.Directory.CreateDirectory(copyPath);
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
      if (dataGridView1.Rows[i].Cells[2].Value != null && 
        !String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()))
    {
        string filePath = dataGridView1.Rows[i].Cells[2].Value.ToString();
        if (System.IO.File.Exists(filePath))
        {                   
            string fileName = System.IO.Path.GetFileName(filePath);
            string newpath = System.IO.Path.Combine(copyPath, fileName);
            System.IO.File.Copy(filePath, newpath, true);
            dataGridView1.Rows[i].Cells[3].Value = newpath;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=SREEJITHMOHA492\SQLEXPRESS;Initial Catalog=cndb;Integrated Security=True");
             {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "update cncinfo set draftpath=@draftpath,releasepath=@releasepath Where part=@part";
                    cmd.Parameters.Add("@draftpath",SqlDbType.NVarChar).Value =filePath;
                    cmd.Parameters.Add("@releasepath",SqlDbType.NVarChar).Value =newpath;
                    cmd.CommandText = "update cncinfo set draftpath='" + string.Empty + "',releasepath=@releasepath Where part=@part";
                    //you must have the id value in datagridview to update the specific record.
                    cmd.Parameters.Add("@part",SqlDbType.NVarChar).Value =Convert.ToString(dataGridView1.Rows[i].Cells["Part Number"].Value);
                    cmd.ExecuteNonQuery();
                    con.Close();
             }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        dataGridView1.Rows[i].Cells[2].Value = string.Empty;
    }
    }
    }
