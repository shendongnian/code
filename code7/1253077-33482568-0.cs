    string line;
    using (SqlConnection con = new SqlConnection(@"Data Source=NT;Initial Catalog=SinhVien;Integrated Security=True"))
    {
        con.Open();
        using(StreamReader file = new StreamReader(@"D:\a.txt")
        {
             while((line = file.ReadLine()) != null)
             {
                 string[] fields = line.Split(',');
                 SqlCommand cmd = new SqlCommand("INSERT INTO Sinhvien(ID, HoTen, DiaChi) VALUES (@id, @hoten, @diachi)", con);
                 cmd.Parameters.AddWithValue("@id", fields[0].ToString());
                 cmd.Parameters.AddWithValue("@hoten", fields[1].ToString());
                 cmd.Parameters.AddWithValue("@diachi", fields[2].ToString());
                 cmd.ExecuteNonQuery();
             }
        }
    }
