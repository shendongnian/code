	class Program
	{
        //Example enum
		public enum eFancyEnum
		{
			[Description("Obsolete")]
			Yahoo,
			[Description("I want food")]
			Meow,
			[Description("I want attention")]
			Woof,
		}
		static void Main(string[] args)
		{
            //This is how you use it
			Dictionary<eFancyEnum, string> myDictionary = typeof(eFancyEnum).ToDictionary<eFancyEnum>();
		}
	}
	public static class EnumExtension
	{
        //Helper method to get description
		public static string ToDescription<T>(this T en)
		{
			 Type type = en.GetType();
			 MemberInfo[] memInfo = type.GetMember(en.ToString());
			 if (memInfo != null && memInfo.Length > 0)
			 {
				object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
				if (attrs != null && attrs.Length > 0)
				   return ((DescriptionAttribute)attrs[0]).Description;
			 }
			 return en.ToString();
		}
        //The actual extension method that builds your dictionary
		public static Dictionary<T, string> ToDictionary<T>(this Type source) where T : struct, IConvertible
		{
			 if(!source.IsEnum || typeof(T) != source)
			 {
				throw new InvalidEnumArgumentException("BOOM");
			 }
			 Dictionary<T, string> retVal = new Dictionary<T,string>();
			 foreach (var item in Enum.GetValues(typeof(T)).Cast<T>())
			  {
				retVal.Add(item, item.ToDescription());
			  }
			 return retVal;
		}
	}
