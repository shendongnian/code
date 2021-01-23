    class objType
    {
    	public int Field1 { get; set; }
    	public string Field2 { get; set; }
    	public int Field3 { get; set; }
    
    	public bool AreEqual(object other)
    	{
    		var otherType = other as objType;
    		if (otherType == null)
    			return false;
    		return Field1 == otherType.Field1 && Field2 == otherType.Field2 && Field3 == otherType.Field3;
    	}
    }
    var tableOne = new objType[] {
		new objType { Field1 = 1, Field2 = "aaaa", Field3 = 100 },
		new objType { Field1 = 2, Field2 = "bbbb", Field3 = 200 },
		new objType { Field1 = 3, Field2 = "cccc", Field3 = 300 },
		new objType { Field1 = 4, Field2 = "dddd", Field3 = 400 }
	};
	var tableTwo = new objType[] {
		new objType { Field1 = 2, Field2 = "xxxx", Field3 = 200 },
        new objType { Field1 = 3, Field2 = "cccc", Field3 = 999 },
        new objType { Field1 = 4, Field2 = "dddd", Field3 = 400 },
        new objType { Field1 = 5, Field2 = "eeee", Field3 = 500 }
	};
	
	var originalIds = tableOne.ToDictionary(o => o.Field1, o => o);
	var newIds = tableTwo.ToDictionary(o => o.Field1, o => o);
	
	var deleted = new List<objType>();
	var modified = new List<objType>();
	foreach (var row in tableOne)
	{
		if(!newIds.ContainsKey(row.Field1))
			deleted.Add(row);
		else 
		{
			var otherRow = newIds[row.Field1];
			if (!otherRow.AreEqual(row))
            {
				modified.Add(row);
				modified.Add(otherRow);
			}
		}
	}
	
	var added = tableTwo.Where(t => !originalIds.ContainsKey(t.Field1)).ToList();
