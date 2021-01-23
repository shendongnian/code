    static void Main(string[] args)
    {
        var info = DeviceType.Stb.GetAttribute<DeviceInformationAttribute>();
        Console.WriteLine("Description: {0}\nValue:{1}",info.Description, info.Value);
    }
    
    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
    public enum DeviceType
    {
        [DeviceInformation("foobar", "100")]
        Stb = 1,
    }
    
