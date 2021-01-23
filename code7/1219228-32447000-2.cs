    static void Main(string[] args)
    {
        Console.WriteLine("Please input string");
        string input = Console.ReadLine();
        NewString ns = new NewString();
        StringOperation so = new StringOperation();
        so.PrintBeforeSwitch(input);
        ns.SwitchLetters(input);
        so.PrintAfterSwitch(input);   
    }
