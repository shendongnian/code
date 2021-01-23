	var properties = typeof(OriginalObject).GetProperties()
	                                       .Where(p => PropertyNames.Contains(p.Name))
                                           .ToList();
	var output = obj.Select(o => {
	    dynamic x = new ExpandoObject();
	    var temp = x as IDictionary<string, Object>;
		foreach(var property in properties)
			temp.Add(property.Name, property.GetValue(o));
		return x;
	});
