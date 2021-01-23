    foreach (var item in items)
    {
    	var obj = new ExpandoObject() as IDictionary<string, Object>;
    	obj.Add("PropA", item.PropA);
    		
    	foreach (var role in roles)
    	{
    		obj.Add(role.Name,
    				String.Join(",", item.UserRole.Where(x => x.Role == role).Select(x => x.User.Name)));
    	}
    	// omitted...
    }
