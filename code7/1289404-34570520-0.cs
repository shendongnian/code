    using(MySqlConnection sql = @"Data Source=127.0.0.1; 
          Database==testowa;uid=kuba;Pwd=123;Port=3306"))
    {
        try
        {
            sql.Open();
            MessageBox.Show("Connected!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("not connected :(" + ex.Message);
        }
    }
