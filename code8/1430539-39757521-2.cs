    _table = new DataTable();
    _table.Load(dataStream);
    _set = new DataSet();
    _set.Tables.Add(_table);
    _set.GetXml();
    Debug.WriteLine(_set.GetXml());
