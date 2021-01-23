    public enum MyEnum
    {
         [Description("My Foo Member")]
         FooMember,
         Bar_Member
    }
    ...
    public static string GetFriendlyName(Enum enumValue)
	{
        var descriptionAttribute = ReflectionUtil.GetAttribute<DescriptionAttribute>(enumValue);
        return descriptionAttribute != null
			? descriptionAttribute.Description
			: enumValue.ToString(); // or .Replace("_", " ") for example
    }
