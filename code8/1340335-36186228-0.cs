    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True");
    SqlTransaction trans = con.BeginTransaction();
    con.Open();
    string sql = "INSERT INTO Elevi (Nume , Prenume , SportulPracticat) VALUES(@nume,@prenume,@sport)";
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        cmd.Transaction = trans;
        cmd.Parameters.AddWithValue("@nume", textBox1.Text);
        cmd.Parameters.AddWithValue("@prenume", textBox2.Text);
        cmd.Parameters.AddWithValue("@sport", textBox3.Text);
        cmd.ExecuteNonQuery();
        trans.Commit();
    }
    con.Close();
