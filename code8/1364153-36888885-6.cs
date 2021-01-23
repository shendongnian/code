    string kdquery = "INSERT INTO Kunden VALUES (@Kundennummer, @Kundenname, @Kundenmail, @Telefon)";
    using (SqlConnection updatedb = new SqlConnection("..."))
    {
        updatedb.Open();
        for (int i = 0;i<dataGridView1.Rows.Count;i++)
        {
           using (SqlCommand insert = new SqlCommand(kdquery, updatedb))
           {
               insert.Parameters.AddWithValue("@Kundenname", dataGridView1.Rows[i].Cells["Kundenname"].Value); 
               insert.Parameters.AddWithValue("@Kundennummer", dataGridView1.Rows[i].Cells["Kundennummer"].Value); 
               insert.Parameters.AddWithValue("@Kundenmail", dataGridView1.Rows[i].Cells["Kundenmail"].Value);
               insert.Parameters.AddWithValue("@Telefon", dataGridView1.Rows[i].Cells["Telefon"].Value);
    
               insert.ExecuteNonQuery();
           }
        }
    }
