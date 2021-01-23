    public void SwitchLetters(string newStr)
    {
        try
        {
         
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadLine();//this stops the program so you can read the error
        }
    }
    //I think you had the two lines swapped around so.PrintBeforeSwitch and ns.SwitchLetters    
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
