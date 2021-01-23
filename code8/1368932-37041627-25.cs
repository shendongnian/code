    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            input = "{[()]} }[]{ {()[] {()[]} ({)}"; //get through tests faster
        var data = input.Split(' ')
                        .Select(s => new {Input = s, Result = CheckString(s)?"YES":"NO"});
        foreach(var item in data)
        {   //guessing at input length here
            Console.WriteLine("{0,-26} \t--{1,5}", item.Input, item.Result);
        }
        //just because the question asked for an array
        var result = data.Select(i => i.Result).ToArray();
    }
