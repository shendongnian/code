    SqlConnection conn = new SqlConnection("Server = .\\SQLEXPRESS; Initial Catalog= Student; Trusted_Connection = True");
    string query = "select Id, Name from abc1";
    SqlDataAdapter da = new SqlDataAdapter();
    conn.Open();
    DataTable dt = new DataTable();
    
    SqlCommand command = new SqlCommand(query, conn);
    
    SqlDataReader reader = command.ExecuteReader();
    
    dt.Load(reader);
    
    DataRow Drw;
    Drw = dt.NewRow();
    Drw.ItemArray = new object[] { 0, "<----Select---->" };
    dt.Rows.InsertAt(Drw, 0);
    
    comboBox1.DataSource = dt;
    comboBox1.ValueMember = "Id";
    comboBox1.DisplayMember = "Name";
