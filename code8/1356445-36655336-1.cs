    string _connStr = @"Data Source = EJQ7FRN; Initial Catalog = BES; Integrated Security = True";
    string _query = "INSERT INTO [BES_S] (ISN,Titel,Name) ";
    _query = _query + " SELECT @ISN, @Titel, @Name FROM DUAL";
    _query = _query + " WHERE NOT EXISTS (SELECT ISN WHERE ISN=@ISN)";
    using (SqlConnection conn = new SqlConnection(_connStr))
    {
        using (SqlCommand comm = new SqlCommand())
        {
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = _query;
            comm.Parameters.AddWithValue("@ISN", txtISN.Text);
            comm.Parameters.AddWithValue("@Titel",txtTitel.Text);
            comm.Parameters.AddWithValue("@Name", txtName.Text);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
            }
        }
    }
