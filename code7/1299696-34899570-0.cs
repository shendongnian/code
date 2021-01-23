     string st=ds.Tables[0].Rows[i][dc.ColumnName].ToString();
    try
    {
    DateTime dateTime;
    DateTime.TryParse(st, out dateTime);
    }
    catch()
    {
    }
