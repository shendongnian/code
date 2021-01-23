    public interface IParser
    {
        string platformName { get; }
        bool isThisPlatform(string asmFileContents);
        bool parseAsm(string asmFileContents);
    }
    class PIC32MX_GCC_Parser : IParser
    {
        private PIC32MX_GCC_Parser()
        {
        }
        public static string platformName { get { return "PIC32MX_GCC"; } }
        public static bool isThisPlatform(string asmFileContents)
        {
            return false; // stub
        }
        public static bool parseAsm(string asmFileContents)
        {
            return false; // stub
        }
        private static readonly PIC32MX_GCC_Parser _instance = new PIC32MX_GCC_Parser();
        public static IParser Instance
        {
            get { return _instance; }
        }
        string IParser.platformName { get { return platformName; } }
        bool IParser.isThisPlatform(string asmFileContents)
        {
            return isThisPlatform(asmFileContents);
        }
        bool IParser.parseAsm(string asmFileContents)
        {
            return parseAsm(asmFileContents);
        }
    }
    class M16C_IAR_Parser : IParser
    {
       //..snip
    }
    Parser[] parsers =
    {
     PIC32MX_GCC_Parser.Instance,
     M16C_IAR_Parser.Instance
    };
    public IParser findTheRightParser(string asmFileContents)
    {
        foreach (IParser parser in parsers)
        {
            if (parser.isThisPlatform(asmFileContents))
            {
                Console.WriteLine("Using parser: ", parser.platformName);
                return parser;
            }
        }
        return null;
    }
