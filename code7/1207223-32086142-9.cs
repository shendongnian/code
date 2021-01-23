    private void txt_SearchUser(object sender, TextChangedEventArgs e)
    {
        _con = new SqlConnection(_strConn);
        try
        {
            _con.Open();
            string query = "select id_int_user, name_str_user from tbl_user";
            if(txt_Search.Text != "") // Note: txt_Search is the TextBox..
            {
                query += " where id_int_user = " + txt_Search.Text;
            }
            _cmd = new SqlCommand(query, _con);
            _cmd.ExecuteNonQuery();
    
            _adp = new SqlDataAdapter(_cmd);
            _dt = new DataTable("tbl_user");
            _adp.Fill(_dt);
            dtgUser.ItemsSource = _dt.DefaultView;
            _adp.Update(_dt);
    
            _con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
