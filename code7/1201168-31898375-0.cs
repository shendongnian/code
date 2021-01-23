    SQLiteConnection connection = XpoDefault.Session.Connection as SQLiteConnection;
    connection.ChangePassword(string.Empty);
    string st = string.Format("attach database '{0}' as AttachedAlias", s);
    XpoDefault.Session.ExecuteNonQuery(st);
            
