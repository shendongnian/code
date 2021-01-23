    private static string GetInsertString<TDto>(TDto someObject) {
    	var type = typeof(TDto);
    	var properties = type.GetProperties();	// Removed .Where(Where) since it didn't compile
    	var tableName = type.Name;
    
    	return string.Format(
    		"INSERT INTO {0} ({1}) VALUES ({2});", 
    		tableName, 
    		string.Join(",", properties.Select(x => x.Name).ToArray()),
    		string.Join(",", properties.Select(x => string.Format("@{0}", x.Name.ToLower())).ToArray())
    	);
    }
    
    var point = new { X = 13, Y = 7 };
    var insertSql = Test.GetInsertString(point);
    // Results in: INSERT INTO <>f__AnonymousType0`2 (X,Y) VALUES (@x,@y);
