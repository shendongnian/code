    States s;
	var type = typeof(States);
	foreach (var field in type.GetFields())
	{
		var attribute = Attribute.GetCustomAttribute(field,
			typeof(DescriptionAttribute)) as DescriptionAttribute;
		if (attribute != null)
		{
			if (attribute.Description == "description")
			{
				s = (States)field.GetValue(null);
				break;
			}
		}
		else
		{
			if (field.Name == "description")
			{
				s = (Rule)field.GetValue(null);
				break;
			}
		}
	} 
