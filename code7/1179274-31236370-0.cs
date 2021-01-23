    private List<String> GetEnumNames(Type enumType)
    {
    	return enumType.GetMembers(BindingFlags.Public | BindingFlags.Static).Select(m => { 
    		var attr = m.GetCustomAttribute<EnumMemberAttribute>();
    		if (attr != null)
    			return attr.Value;
    		return m.Name;
    	}).ToList();
    }
