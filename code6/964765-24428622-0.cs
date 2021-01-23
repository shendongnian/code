        ...
        string sql = "SELECT ... WHERE username = ?";
        db.GetDataTable(sql, comboMasterUsers.SelectedItem.ToString());
        ...
    public DataTable GetDataTable(string sql, params Object[] parameters)
    {
        ...
        mycommand.CommandText = sql;
        foreach (var value in parameters)
        {
            var param = mycommand.CreateParameter();
            param.Value = value;
            mycommand.Parameters.Add(param);
        }
        ...
