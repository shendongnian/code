    public void Dispose ()
	{
	    Dispose (true);
        GC.SuppressFinalize (this);
    }
    protected virtual void Dispose (bool disposing)
    {
        Close ();
    }
	public void Close ()
	{
		if (_open && Handle != NullHandle) {
			try {
				if (_mappings != null) {
					foreach (var sqlInsertCommand in _mappings.Values) {
						sqlInsertCommand.Dispose();
					}
				}					
                var r = SQLite3.Close (Handle);
				if (r != SQLite3.Result.OK) {
					string msg = SQLite3.GetErrmsg (Handle);
					throw SQLiteException.New (r, msg);
				}
			}
			finally {
				Handle = NullHandle;
				_open = false;
			}
		}
	}
