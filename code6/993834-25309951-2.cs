    public static void Main()
    {
    	
    	var _testClass = new TestClass();
    	
		_testClass.AttributeList.Add(new CustomAttribute<string>{Key = "TestKey", Value = "a"});
		_testClass.AttributeList.Add(new CustomAttribute<int>{Key = "TestKey", Value = 1337});
		_testClass.AttributeList.Add(new CustomAttribute<int>{Key = "TestKey", Value = 1});
		_testClass.AttributeList.Add(new CustomAttribute<int>{Key = "TestKey", Value = 6});
		_testClass.AttributeList.Add(new CustomAttribute<double>{Key = "TestKey", Value = 3.141592654});
		_testClass.AttributeList.Add(new CustomAttribute<string>{Key = "TestKey", Value = "x"});
		_testClass.AttributeList.Add(new CustomAttribute<bool>{Key = "TestKey", Value = true});
    	
    	// Build a new list with all the different Types
    	List<Type> types = new List<Type>();
    	// Loop over all Attributes in _testClass
    	foreach (var a in _testClass.AttributeList) {
    		// See if this Type is alreadyin the List
    		if (types.Contains(a.GetType())) continue;
    		// Add it to the List
    		types.Add(a.GetType());
    	}
    	Type[] _extraTypes = types.ToArray();
    	
    	var serializer = new XmlSerializer(typeof(TestClass), _extraTypes);
    	
        using (Stream str = new MemoryStream())
        {
            serializer.Serialize(str, _testClass);
        }
    }
