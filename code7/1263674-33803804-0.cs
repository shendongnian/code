    foreach(var session in ITS.GetSessions())
    {
        Type t = session.GetType();
        PropertyInfo[] propinfo = t.GetProperties();
        var list = new List<object>();
        foreach (PropertyInfo prop in propinfo)
        {
            list.Add(prop.GetValue(session, null));
        }
        DTable.Rows.Add(list.ToArray());   
    }
