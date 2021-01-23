    void Main()
    {
    	Console.WriteLine("M".SearchEnum<GenderContract>());
    }
    public static class EnumHelpers
    {
       public static T SearchEnum<T>(this string value)
       {
           if (value == null)
			  return default(T);
           // Get the string names for the Enum
           List<string> enumStrings = Enum.GetNames(typeof (T)).ToList();
           string matchingEnumString = enumStrings.FirstOrDefault(x => x.StartsWith(value));
    
           return ParseEnum<T>(matchingEnumString);
    
       }
    
       public static T ParseEnum<T>(this string value)
       {
           if (value == null)
			  return default(T);
           return (T)Enum.Parse(typeof(T), value, true);
       }
    }
    
    public enum GenderContract
    {
       Male,
       Female,
       Unknown
    }
