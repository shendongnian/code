    SqlConnection con = new SqlConnection();
    con.ConnectionString = "Data Source=(local);Initial Catalog=songs_db;Persist Security Info=True;User ID=sa;Password=iloveyourb";
    con.Open();
    DataSet ds = new DataSet();
    String sql = "Select * From tbl_songdb";
    SqlDataAdapter da = new SqlDataAdapter(sql, con);
    da.Fill(ds);
    DataRow drow = ds.Tables[0].NewRow();  // I am getting error message here.
    drow[1] = txt_songName.Text;
    drow[2] = txt_minute.Text;
    drow[3] = txt_albumnName.Text;
    drow[4] = txt_location.Text;
    ds.Tables[0].Rows.Add(drow);
    SQLiteCommandBuilder cmdbuilder = new SQLiteCommandBuilder(da);
    da.InsertCommand = cmdbuilder.GetInsertCommand();
    da.Update(ds);
    ds.AcceptChanges();
    con.Close();
