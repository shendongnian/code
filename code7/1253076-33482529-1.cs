    // If the file is small, read it all at once
    string[] lines = File.ReadAllLines(@"D:\a.txt");
    // TODO: if lines is empty, bail out
    using (SqlConnection con = new SqlConnection(@"Data Source=NT;Initial Catalog=SinhVien;Integrated Security=True"))
    {
        con.Open();
        // for each line (no ifs or whiles here)
        foreach (var line in lines)
        {
            string[] fields = line.Split(',');
            // TODO: verify fields contain what you want
            // SqlCommand implements IDisposable too
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Sinhvien(ID, HoTen, DiaChi) VALUES (@id, @hoten, @diachi)", con))
            {
                cmd.Parameters.AddWithValue("@id", fields[0]); // these are already strings, no ToString()s needed
                cmd.Parameters.AddWithValue("@hoten", fields[1]);
                cmd.Parameters.AddWithValue("@diachi", fields[2]);
                cmd.ExecuteNonQuery();
            }
        }
    }
