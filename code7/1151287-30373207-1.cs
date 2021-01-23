    public class Atbash {
        static string source = "abcdefghijklmnopqrstuvwxyz";
        static List<char> keys = source.ToList();
        static List<char> values = source.Reverse().ToList();
        static Dictionary<char, char> Converter = keys.ToDictionary(x => x, x => values[keys.IndexOf(x)]);
        public static char Convert(char input)
        {
            char output;
            bool isUpper = char.IsUpper(input);
            input = char.ToLowerInvariant(input);
            if(Converter.ContainsKey(input)) {
                output =  Converter[input];
                return (isUpper) ? char.ToUpperInvariant(output) : output;
            }
            throw new ArgumentOutOfRangeException("Input char is unknown");
            // of course, it can return default(char) instead of throwing an exception.
        }
    }
