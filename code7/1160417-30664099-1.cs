    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = new[]
            {
                "ABCTest",
                "HelloWorld",
                "testTest$Test",
                "aaҚbb"
            };
            var output = inputs.Select(x => x.SplitWithSpaces(CultureInfo.CurrentUICulture));
            foreach (string x in output)
            {
                Console.WriteLine(x);
            }
            Console.Read();
        }
    }
    public static class StringExtensions
    {
        public static bool IsLowerCase(this TextInfo textInfo, char input)
        {
            return textInfo.ToLower(input) == input;
        }
        public static string SplitWithSpaces(this string input, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
            }
            TextInfo textInfo = culture.TextInfo;
            StringBuilder sb = new StringBuilder(input);
            for (int i = 1; i < sb.Length; i++)
            {
                int previous = i - 1;
                if (textInfo.IsLowerCase(sb[previous]))
                {
                    int insertLocation = previous - 1;
                    if (insertLocation > 0)
                    {
                        sb.Insert(insertLocation, ' ');
                    }
                    while (i < sb.Length && textInfo.IsLowerCase(sb[i]))
                    {
                        i++;
                    }
                }                
            }
            return sb.ToString();
        }
    }
