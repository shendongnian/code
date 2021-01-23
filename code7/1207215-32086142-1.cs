    private void txt_SearchUser(object sender, TextChangedEventArgs e)
    {
        _con = new MySqlConnection(_strConn);
        try
        {
            _con.Open();
            string query = "select device_id, device_name from privilege_device";
            if(txt_Search.Text != "")
            {
                query += " where device_id = " + txt_Search.Text;
            }
            _cmd = new MySqlCommand(query, _con);
            _cmd.ExecuteNonQuery();
    
            _adp = new MySqlDataAdapter(_cmd);
            _dt = new DataTable("privilege_device");
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
