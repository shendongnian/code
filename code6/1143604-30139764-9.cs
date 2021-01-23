    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select titel, genre, release_year, console, ownedby, loaned from spil";
            cmd.Connection = DatabaseConnection.GetDefaultConnection();
    
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd;
    
            DataTable dTable = new DataTable("spil");
    
            MyAdapter.Fill(dTable);
    
            DataGridSpil.ItemsSource = dTable.DefaultView;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
