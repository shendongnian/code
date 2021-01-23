    public dynamic Example7(Type listOfType)
	{
		CreateObject<Dummy> a1 = DummyRepository.InsertAsync;
		if (listOfType == typeof(Dummy)) return (CreateObject<Dummy>)DummyRepository.InsertAsync;
		if (listOfType == typeof(DummyName)) return (CreateObject<DummyName>)DummyNameRepository.InsertAsync;
		if (listOfType == typeof(DummyEntry)) return (CreateObject<DummyEntry>)DummyEntryRepository.InsertAsync;
		return null;
	}
