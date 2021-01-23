    public static void Main() {
    {
        Console.WriteLine(GetValueOf(typeof(EnumClass.Colors), "Red"));
    }
    public static int GetValueOf(Type enumType, string enumConst)
    {
        object value = Enum.Parse(enumType, enumConst);
        return Convert.ToInt32(value);
    }
