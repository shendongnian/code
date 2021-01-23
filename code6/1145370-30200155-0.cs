    using (var con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\ProgramData\MyDB\TestingDB.mdf;Integrated Security=True;Connect Timeout=30"))
    using (var cmd1 = new SqlCommand("INSERT INTO Customer (cus_name, cus_address, cus_Image)Values(@name, @address, @image);", con))
    {
        var imageData = new MemoryStream();
        pictureBox1.Image.Save(imageData, pictureBox1.Image.RawFormat);
        cmd1.Parameters.AddWithValue("@name", textBox1.Text);
        cmd1.Parameters.AddWithValue("@address", textBox2.Text);
        cmd1.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageData.ToArray();
        con.Open();
        var result = cmd1.ExecuteNonQuery();
    }
