	public static class CSharpCodeDomExtensions
	{
		// Taken from CSharpCodeGenerator.GetBaseTypeOutput(CodeTypeReference typeRef)
		private static readonly HashSet<string> BaseTypes = new HashSet<string>
		{
			"system.int16", "system.int32", "system.int64", 
			"system.string", "system.object", "system.boolean", "system.void", 
			"system.char", "system.byte", 
			"system.uint16", "system.uint32", "system.uint64", 
			"system.sbyte", 
			"system.single", "system.double", "system.decimal"
		};
		private static bool IsBaseType(string fullName)
		{
            // It is done in this way in CSharpCodeGenerator.GetBaseTypeOutput
			return BaseTypes.Contains(fullName.ToLower(CultureInfo.InvariantCulture).Trim());
		}
		public static string StripNameSpaces(this Type type)
		{
			string fullName = type.FullName;
			if (IsBaseType(fullName))
			{
				return fullName;
			}
			return fullName.Split('.').Last();
		}
		public static string StripNameSpaces(this string fullName)
		{
			if (IsBaseType(fullName))
			{
				return fullName;
			}
			return fullName.Split('.').Last();
		}
	}
