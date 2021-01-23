	foreach (DictionaryEntry entry in ex.Data)
	{
		// you will want to use a StringBuilder instead of concatenating strings if you do this
		exceptionMessage = exceptionMessage + string.Format("Exception.Data[{0}]: {1}", entry.Key, entry.Value);
	}
	
