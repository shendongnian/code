    public enum Versions
    {
        Test = 1,
        [Description("No Test!!")]
        NoTest = 2
    }
    // NOTE: this function taken from http://stackoverflow.com/questions/18625488/alternative-names-for-c-sharp-enum
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            }
            return value.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enum Test has name of {Enum.GetName(typeof(Versions), Versions.Test)} and a value of {(int)Versions.Test}");
            Console.WriteLine($"Enum NoTest has description of {EnumExtensions.GetDescription(Versions.NoTest)} and a value of {(int)Versions.NoTest}");
            return;
