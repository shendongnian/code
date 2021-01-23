    int currentVersion = GetDBVersionNumber();
    
    string scriptFile = "UPGRADE_DB.XML";
    DataSet ds = new DataSet();
    ds.ReadXml(scriptFile, XmlReadMode.ReadSchema);
    string filter = "Version > " + currentVersion.ToString();
    string sort = "Version";
    DataRow[] rows = ds.Tables[0].Select(filter, sort);
    if (rows.Length == 0)
        return;
        
    try
    {
        using(SQLiteConnection cnn = new SQLiteConnection(.....))
        using(SQLiteCommand cmd = cnn.GetCommand())
        {
            foreach (DataRow dr in rows)
            {
                cmd.CommandText = dr.Field<string>("Command");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                UpdateDBVersionNumber(dr.Field<int>("Version"));
                WriteLog(currentVersion);
            }
        }
    }
    catch(Exception ex)
    {
        WriteLog(ex);
    }
