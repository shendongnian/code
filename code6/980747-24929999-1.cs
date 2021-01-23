        static void Main(string[] args)
        {
            string originalString= "\r\radmin@Modem -- *<456> \radmin@Modem -- *<456> ";
            Regex reg = new Regex(@"-- \*<[1-9][0-9]*>");
            bool isMatch = reg.IsMatch(originalString);
            Console.WriteLine(isMatch);
        }
