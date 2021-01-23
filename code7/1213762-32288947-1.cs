    try
    {
        using(SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString))
        using(SqlCommand cmd = new SqlCommand(string.Empty, con))
        {
            cmd.CommandText = "select Picture from Person";
            con.Open();
    
            byte[] image = (byte[])cmd.ExecuteScalar();
            
            using (MemoryStream stream = new MemoryStream(image))
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
