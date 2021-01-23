    private class SomeClass
	{
		public string Name { get; set; }
	}
    ...
    Dictionary<uint, SomeClass> dic = new Dictionary<uint, SomeClass>
    { 
      { 1u, new SomeClass { Name = "1"}},
      { 2u, new SomeClass { Name = "2"}}
    };
    var sc1 = dic[1]; // sc1 refers to old instance of SomeClass
    dic[1] = new SomeClass { Name = "new" }; // now we change the reference here
    string oldName = sc1.Name; // oldName is still "1", because sc1 points to the old instance
