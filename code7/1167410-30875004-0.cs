	public IEnumerator<DataBase> GetEnumerator() {
		if (this is DataList)
			return ((DataList)this).GetEnumerator();
		else if (this is DataDictionary)
			return ((DataDictionary)this).Values.GetEnumerator();
		else throw new NotSupportedException();
	}
