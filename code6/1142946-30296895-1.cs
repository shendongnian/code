    [DllImport("sqlite3", EntryPoint = "sqlite3_prepare_v2", CallingConvention = CallingConvention.Cdecl)]
    private static extern SQLite3.Result Prepare2(IntPtr db, byte[] queryBytes, int numBytes, out IntPtr stmt, IntPtr pzTail);
    private Sqlite3Statement Prepare2()
    {
        IntPtr statement;
        var queryBytes = System.Text.Encoding.UTF8.GetBytes(CommandText);
        var result = Prepare2(_conn.Handle, queryBytes, queryBytes.Length, out statement, IntPtr.Zero);
        if (result != SQLite3.Result.OK)
        {
            throw SQLiteException.New(result, SQLite3.GetErrmsg(_conn.Handle));
        }
        BindAll(statement);
        return statement;
    }
