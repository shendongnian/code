    static void Main(string[] args)
    {
        var data = Console.ReadLine().Split(' ')
                            .Select(s => new {Input = s, Result = CheckString(s)?"YES":"NO"});
        foreach(var item in data)
        {
            Console.WriteLine("{0,-25}  --{1,5}", item.Input, item.Result);
        }
        //just because the question asked for an array
        var result = data.Select(i => i.Result).ToArray();
    }
