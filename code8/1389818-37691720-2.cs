    public static string Name { get; set; }
    static void Main(string[] args)
    {
        Name = args[0]; // taking the First value from the args array
        //or use String.Join to get all elements from args
        string delemitter = "";
        Name = String.Join(delemitter, args);
    }
