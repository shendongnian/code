    var kdNummer = new SqlParameter("@Kundennummer", SqlDbType.Int);
    var kdName = new SqlParameter("@Kundenname", SqlDbType.VarChar);
    var kdMail = new SqlParameter("@Kundenmail", SqlDbType.VarChar);
    var kdTele = new SqlParameter("@Telefon", SqlDbType.VarChar);
    
    string kdquery = "INSERT INTO Kunden VALUES (@Kundennummer, @Kundenname, @Kundenmail, @Telefon)";
    using (SqlConnection updatedb = new SqlConnection("..."))
    {
        updatedb.Open();
        for (int i = 0;i<dataGridView1.Rows.Count;i++)
        {
           using (SqlCommand insert = new SqlCommand(kdquery, updatedb))
           {
               kdName.Value = dataGridView1.Rows[i].Cells["Kundenname"].Value;
               kdNummer.Value = dataGridView1.Rows[i].Cells["Kundennummer"].Value;                     
               kdMail.Value = dataGridView1.Rows[i].Cells["Kundenmail"].Value;
               kdTele.Value = dataGridView1.Rows[i].Cells["Telefon"].Value;
               insert.Parameters.Add(kdName);
               insert.Parameters.Add(kdNummer);
               insert.Parameters.Add(kdMail);
               insert.Parameters.Add(kdTele);
    
               insert.ExecuteNonQuery();
           }
        }
    }
