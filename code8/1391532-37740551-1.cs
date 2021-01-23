    DateTime dtFrom =Convert.ToDateTime(DatePicker1.Text); //some DateTime value, e.g. DatePicker1.Text;
    DateTime dtTo =Convert.ToDateTime(DatePicker2.Text); //some DateTime value, e.g. DatePicker1.Text;
    MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=8888;password=888888");
    MySqlDataAdapter mda = new MySqlDataAdapter("select * from bio_db.daily_data2 where Date between '" + dtFrom.ToString("MM/dd/yyyy")+ "' and '" + dtTo.ToString("MM/dd/yyyy") + "' ", mcon);
    DataSet ds = new DataSet();
    mda.Fill(ds);
    dbgrid1.DataSource = ds;
    dbgrid1.Refresh();
    mcon.Close();
