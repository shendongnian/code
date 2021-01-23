	string findMe = "625 ILCS 5/11-503 - Reckless Driving";
    Type enumType = typeof(IllinoisNonDisclosureConvictionFormOptions);
	Type descriptionAttributeType = typeof(DescriptionAttribute);
	foreach (string memberName in Enum.GetNames(enumType))
	{
		MemberInfo member = enumType.GetMember(memberName).Single();
	
		string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
		
		if (findMe.Equals(memberDescription))
		{
			Console.WriteLine("Found it!");
		}
	}
