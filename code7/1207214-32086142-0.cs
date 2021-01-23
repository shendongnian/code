    private void txt_SearchUser(object sender, TextChangedEventArgs e)
    {
        DataTable tempDt = _dt.Copy();
        tempDt.Clear();
        if (txt_Search.Text != "")
        {
            foreach (DataRow dr in _dt.Rows)
            {
                if (dr["device_id"].ToString().Contains(txt_Search.Text))
                {
                    tempDt.ImportRow(dr);
                }
            }
            dtgUser.ItemsSource = tempDt.DefaultView;
        }
        else
        {
            dtgUser.ItemsSource = _dt.DefaultView;
        }
    }
