        var c = new TestClass() {TestString = "SimpleStringfield", TestDate = DateTime.Today,TestStringProperty = "TestStringPropertyContent",
                                  TestStringList = new List<string>(new string[] { "item1","item2","item3"})};
	    var manager = Manager.SharedInstance;
	    var db = manager.GetDatabase("test_database");
	    if (db == null)
	    {
	        System.Diagnostics.Debug.WriteLine("--------------------------Could not open Database");
	    }
	    var doc = db.CreateDocument();
        var properties = new Dictionary<string,Object>() { {"type","day"}, {"day",c} };
	    var rev = doc.PutProperties(properties);
	    var docread = db.GetDocument(doc.Id);
	    JObject testobject = (JObject)docread.GetProperty("day");
	    var o = testobject.ToObject<TestClass>();
	}
