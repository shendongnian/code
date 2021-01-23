    string input = Console.Readline();
    if(IsInt(input))
        int a = int.Parse(input);
    else
        //Error message here
    private bool IsInt(string in)
    {
        string intChars = "0123456789";
        return intChars.contains(in);
    }
