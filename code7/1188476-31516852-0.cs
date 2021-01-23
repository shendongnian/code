    private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(DBHandler.GetConnectionString());
            try
            {
                OpenFileDialog fop = new OpenFileDialog();
                fop.Multiselect = true;
    
                fop.InitialDirectory = @"C:\";
                fop.Filter = "JPG,JPEG|*.jpg|PNG|*png";
                if (fop.ShowDialog() == DialogResult.OK)
                {
    
                    foreach (String files in fop.FileNames)
                    {
                        FileStream FS = new FileStream(@files, FileMode.Open, FileAccess.Read);
                        byte[] img = new byte[FS.Length];
                        FS.Read(img, 0, Convert.ToInt32(FS.Length));
    
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand("SaveImage", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@img", SqlDbType.Image).Value = img;
                        cmd.ExecuteNonQuery();
    
                    }
    
                    MessageBox.Show("Image has been saved successfully!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
