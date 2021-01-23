    public static class ExtensionMethods
    {
        public static string GetMessage(this string source)
        {
            if (source.StartsWith("Message: "))
            {
                source = source.Replace("Message: ", "");
                source = Regex.Replace(source, "-?[0-9]+", "").Trim();
            }
            return source;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String myLine = "Message:  Data have been confirmed -564673154463";
            Console.WriteLine(myLine.GetMessage());
            Console.ReadKey();
        }
    }
