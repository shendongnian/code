      SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local);Initial Catalog=songs_db;Persist Security Info=True;User ID=sa;Password=iloveyourb";
            con.Open();
    try{
            DataSet ds = new DataSet();
            String sql = "Select * From tbl_songdb";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataRow drow = ds.Tables["tbl_songdb"].NewRow();  // I am getting error message here.
            drow[1] = txt_songName.Text;
            drow[2] = txt_minute.Text;
            drow[3] = txt_albumnName.Text;
            drow[4] = txt_location.Text;
            ds.Tables["tbl_songdb"].Rows.Add(drow);
    }
    catch(Exception ex)
    {}
            con.Close();
