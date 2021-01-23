    DateTime dtFrom = Convert.ToDateTime(datefrom.Text); //some DateTime value, e.g. DatePicker1.Text;
    DateTime dtTo = Convert.ToDateTime(dateto.Text); //some DateTime value, e.g. 
    DatePicker1.Text;<n>MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=8888;password=8888888");
    MySqlDataAdapter mda = new MySqlDataAdapter("select * from bio_db.daily_data2 where Date between '" + dtFrom.ToString("yyyy/MM/dd") + "' and '" + dtTo.ToString("yyyy/MM/dd") + "' ", mcon);
            
            System.Data.DataSet ds = new System.Data.DataSet();
            mcon.Open();
            mda.Fill(ds, "root");
            dbgrid1.DataSource = ds.Tables["root"];
            dbgrid1.Refresh();
            mcon.Close();
