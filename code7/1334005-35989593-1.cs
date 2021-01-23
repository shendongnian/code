    string insertQry = "INSERT INTO [dbo].[KlienciIndywidualni] (Imię, Nazwisko, Telefon, E-mail,Adres) " +
                               "VALUES (@Imię, @Nazwisko, @Telefon, @E-mail, @Adres);";
    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mariusz\Desktop\AplikacjaNaInzynierie\AplikacjaNaInzynierie\Baza.mdf;Integrated Security=True"))
        using (SqlCommand cmd = new SqlCommand(insertQry, conn))
        {
            cmd.Parameters.Add("@Imię", SqlDbType.VarChar, 50).Value = textBox1.Text;
            cmd.Parameters.Add("@Nazwisko", SqlDbType.VarChar, 50).Value = textBox2.Text;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar, 50).Value = textBox3.Text;
            cmd.Parameters.Add("@E-mail", SqlDbType.VarChar, 50).Value = textBox4.Text;
            cmd.Parameters.Add("@Adres", SqlDbType.VarChar, 50).Value = textBox5.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
