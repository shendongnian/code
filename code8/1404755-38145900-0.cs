    SqlConnection sc = new SqlConnection();
    SqlCommand com = new SqlCommand();
    sc.ConnectionString = ("Data Source=ACER;Initial Catalog=BonTempsDB;Integrated Security=True");
    sc.Open();
    
    com.Connection = sc;
    com.CommandText = @"INSERT INTO Klant (Naam, Adres, Woonplaats, Telefoonnummer, EmailAdres) VALUES (@naam, @adres, @woon, @tel, @mail)";
    com.Parameters.AddWithValue("@naam", txtNaam.Text);
    com.Parameters.AddWithValue("@adres", txtAdres.Text);
    com.Parameters.AddWithValue("@woon", txtWoon.Text);
    com.Parameters.AddWithValue("@tel", txtTel.Text);
    com.Parameters.AddWithValue("@mail", txtMail.Text);
    
    com.ExecuteNonQuery();
    sc.Close();
