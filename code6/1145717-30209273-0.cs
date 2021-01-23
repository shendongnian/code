    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GetDataByDescription("New Hampshire"));
        }
        private static int GetDataByDescription(string s)
        {
            foreach (States state in Enum.GetValues(typeof (States)))
            {
                if (GetAttribute<DescriptionAttribute>(state).Description == s)
                {
                    return (int) state;
                }
            }
            throw new ArgumentException("no such state");
        }
        private static TAttribute GetAttribute<TAttribute>(Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }
    }
