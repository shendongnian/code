    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
    SqlCommand cmd = new SqlCommand(string.Empty, con);
    cmd.CommandText = "select Picture from Person";
    con.Open();
    SqlDataReader dataReader = cmd.ExecuteReader();
    dataReader.Read();
    byte[] image = new byte[10000];
    long len = dataReader.GetBytes(0, 0, image, 0, 10000);
    using (MemoryStream mStream = new MemoryStream(image))
    {
        pictureBox1.Image = Image.FromStream(mStream);
    }
