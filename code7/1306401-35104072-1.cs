    class Program
    {
        static void Main(string[] args)
        {
    
            string pattern = @"(\d(?=\d{2})\d(?=\d)\d+)";
            string content = "10" + Environment.NewLine +
                             "1234" + Environment.NewLine +
                             "123 - t123b - +1" + Environment.NewLine +
                             "ff 8765 12";
    
            var reg = new Regex(pattern);
            var replacedText = reg.Replace(content, match => string.Join<char>(" ", match.Value));
    
            Console.WriteLine(replacedText);
    
            Console.ReadLine();
        }
    
    
    }
