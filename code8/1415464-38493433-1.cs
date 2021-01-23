    public class Program
    {
        static void Main(string[] args)
        {
            // Output: #192856
            Console.WriteLine(ConvertRgbaToHex("rgba(25, 40, 86, 1)"));
            
            Console.Read();
        }
        public static string ConvertRgbaToHex(string rgba)
        {
            var matches = Regex.Matches(rgba, @"\d+");
            StringBuilder hexaString = new StringBuilder("#");
            for(int i = 0; i < matches.Count - 1; i++)
            {
                int value = Int32.Parse(matches[i].Value);
                hexaString.Append(value.ToString("X"));
            }
            return hexaString.ToString();
        }
    }
