    SqlConnection con = new SqlConnection("yourconnectionstringhere");
    SqlCommand com = new SqlCommand("SELECT IDPhoto FROM Produksi ORDER BY IDPhoto DESC", con);
    SqlDataAdapter adp = new SqlDataAdapter(com);
    DataTable dt = new DataTable();
    add.SelectCommand = com;
    adp.Fill(dt);
