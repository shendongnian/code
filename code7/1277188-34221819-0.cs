    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        DataView dv = ds.Tables[0].DefaultView;
        dv.RowFilter = string.Format("Name like '%{0}%'", Filter.Text);
        hauptübersichtgrid.ItemsSource = dv;
    }
