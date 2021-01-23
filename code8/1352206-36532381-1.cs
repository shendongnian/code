    class Program
    {
        static void Main(string[] args)
        {
            const string text = "abcde321x zz";
            var morse = new Morse(text);
            Console.WriteLine(morse.Code);
        }
    }
    class Morse
    {
        private static Dictionary<char, string> Codes = new Dictionary<char, string>()
        {
            {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."},
            {'7', "--..."}, {'8', "---.."}, {'9', "----."},
            {'0', "-----"}
        };
        private string Message;
        public string Code
        {
            get
            {
                char firstDigit = this.Message.FirstOrDefault(c => char.IsDigit(c));
                return Codes.ContainsKey(firstDigit) ? Codes[firstDigit] : string.Empty;
            }
        }
        public Morse(string message)
        {
            this.Message = message;
        }
    }
