	//OP's Solution 2
    public static String RollRegex(int number)
    {
        return Regex.IsMatch(number.ToString(), @"(.)\1{1,}$") ? "doubles" : "none";
    }
    //Radin Gospodinov's Solution
    static readonly Regex OptionRegex = new Regex(@"(.)\1{1,}$", RegexOptions.Compiled);
    public static String RollOptionRegex(int number)
    {
        return OptionRegex.IsMatch(number.ToString()) ? "doubles" : "none";
    }
    //OP's Solution 1
    public static String RollEndsWith(int number)
    {
        if (number.ToString().EndsWith("11") || number.ToString().EndsWith("22") || number.ToString().EndsWith("33") ||
            number.ToString().EndsWith("44") || number.ToString().EndsWith("55") || number.ToString().EndsWith("66") ||
            number.ToString().EndsWith("77") || number.ToString().EndsWith("88") || number.ToString().EndsWith("99") ||
            number.ToString().EndsWith("00"))
        {
            return "doubles";
        }
        return "none";
    }
    //Ian's Solution   
    public static String RollSimple(int number)
    {
        string rollString = number.ToString();
        return number > 10 && rollString[rollString.Length - 1] == rollString[rollString.Length - 2] ?
            "doubles" : "none";
    }
    //Ian's Other Solution
    static List<string> doubles = new List<string>() { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
    public static String RollAnotherSimple(int number)
    {
        string rollString = number.ToString();
        return rollString.Length > 1 && doubles.Contains(rollString.Substring(rollString.Length - 2)) ?
            "doubles" : "none";
    }
    //Dandré's Solution
    static HashSet<string> doublesHashset = new HashSet<string>() { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
    public static String RollSimpleHashSet(int number)
    {
        string rollString = number.ToString();
        return rollString.Length > 1 && doublesHashset.Contains(rollString.Substring(rollString.Length - 2)) ?
            "doubles" : "none";
    }
    //Stian Standahl optimizes modded solution
    public static string RollOptimizedModded(int number) { return number % 100 % 11 == 0 ? "doubles" : "none"; }
    //Gjermund Grøneng's method with constant addition
    private const string CONST_DOUBLES = "doubles";
    private const string CONST_NONE = "none";
    public static string RollOptimizedModdedConst(int number) { return number % 100 % 11 == 0 ? CONST_DOUBLES : CONST_NONE; }
    //Corak's Solution, added on Gjermund Grøneng's
    private static readonly string[] Lookup = { "doubles", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none" };
    public static string RollLookupOptimizedModded(int number) { return Lookup[number % 100 % 11]; }
    //Evk's Solution, large Lookup
    private static string[] LargeLookup;
    private static void InitLargeLookup()
    {
        LargeLookup = new string[100000];
        for (int i = 0; i < 100000; i++)
        {
            LargeLookup[i] = i % 100 % 11 == 0 ? "doubles" : "none";
        }
    }
    public static string RollLargeLookup(int number) { return LargeLookup[number]; }
    //Alois Kraus's Solution
    public static string RollNumbers(int number)
    {
        int lastDigit = number % 10;
        int secondLastDigit = (number / 10) % 10;
        return lastDigit == secondLastDigit ? "doubles" : "none";
    }
