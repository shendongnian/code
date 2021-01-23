    SqlConnection edytuj = new SqlConnection("Data Source=MICHAŁ-KOMPUTER;Initial Catalog=ProjektNet_s10772;Integrated Security=True");
        {
            
            SqlCommand xp = new SqlCommand("Update Klient SET Imie = @imie, Nazwisko = @Nazwisko, Adres_Email = @Adres_Email, Telefon = @Telefon, Miasto= @Miasto Where Klient_ID = @Klient_ID", edytuj);
            xp.Parameters.AddWithValue("@Imie", txtimie2.Text);
            xp.Parameters.AddWithValue("@Nazwisko", txtnazwisko2.Text);
            xp.Parameters.AddWithValue("@Adres_Email", txtemail2.Text);
            xp.Parameters.AddWithValue("@Telefon", txttelefon2.Text);
            xp.Parameters.AddWithValue("@Miasto", txtmiasto2.Text);
            xp.Parameters.AddWithValue("@Klient_ID", DropDownList1.Text.Trim());
            edytuj.Open();
            xp.ExecuteNonQuery();
            edytuj.Close();
    
            GridView3.DataBind();
        }
