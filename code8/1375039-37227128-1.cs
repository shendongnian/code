    String sql = @"UPDATE kierowca SET imie=@imie,nazwisko=@nazwisko,
                   data_zatrudnienia=@data_zatrudnienia,pensja=@pensja
                   WHERE imie=@search1 AND nazwisko=@search2";
    using(SqlConnection con = new SqlConnection(......))
    using(SqlCommand cmd = new SqlCommand(sql, con))
    {
        cmd.Parameters.Add("@imie", SqlDbType.NVarChar).Value = txtImie.Text;
        cmd.Parameters.Add("@nazwisko", SqlDbType.NVarChar).Value = txtNazwisko.Text;
        cmd.Parameters.Add("@data_zatrudnienia", SqlDbType.NVarChar).Value = txtData.Text;
        cmd.Parameters.Add("@pensja", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPensja.Text);
        cmd.Parameters.Add("@search1", SqlDbType.Decimal).Value = listBox2.SelectedItem.ToString();
        cmd.Parameters.Add("@search2", SqlDbType.Decimal).Value = listBox3.SelectedItem.ToString();
        con.Open();
        int rowsChanged = cmd.ExecuteNonQuery();
        MessageBox.Show("Updated " + rowsChanged + " rows");
    }
