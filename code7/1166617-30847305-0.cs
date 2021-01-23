    try
    {
        for (int i = 0; i <= 9; i++ )
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT id_czesci_symbol AS KOD,
                                                        ilosc AS ILOSC
                                                 FROM `test`.`zamowienie`
                                                 WHERE z_numer_naprawy='" + numberBox.Content.ToString() + "'
                                                 ORDER BY ilosc LIMIT 5;", connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            if (i < 5)
                czesciTable.DataContext = ds;
            else
                czesciTable2.DataContext = ds;
            cmd.Dispose();
            adp.Dispose();
        }
    }catch (MySqlException ex) {
         MessageBox.Show(ex.ToString());
    }finally {
         connection.Close();
    }
