    var dt4 = new System.Data.DataTable();
    using(var da = new OleDbDataAdapter("select name from Items where exp_dat=@exp_dat", con))
    {
        DateTime dt;
        if(DateTime.TryParseExact(textBox1.Text, "dd/mm/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dt))
        {
            da.SelectCommand.Parameters.Add("@exp_dat", OleDbType.Date).Value = dt;
            da.Fill( dt4 );
        }
    }
