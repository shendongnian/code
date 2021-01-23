    IDataRecord _current;
    public bool MoveNext() // only the essentials
    {
        if (!this._reader.Read())
            return false;
        object[] objArray = new object[_schemaInfo.Length];
        this._reader.GetValues(objArray); // caching into obj array
        this._current = new DataRecordInternal(_schemaInfo, objArray); // a new copy made here
        return true;
    }
	
