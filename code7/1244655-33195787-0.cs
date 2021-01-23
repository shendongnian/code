	public string GetObject<T>(IEnumerable<T> obj)
	{
		 var output = fh.WriteString(obj);
		 return output;
	}
