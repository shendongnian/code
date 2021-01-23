    static void Main(string[] args)
    {
        var result = Console.ReadLine().Split(' ')
                            .Select(s => new {Input = s, Result = CheckString(s)?"YES":"NO"});
        foreach(var item in result)
        {
            Console.WriteLine("{0,-25}  --{1,5}", item.Input, item.Result);
        }
    }
