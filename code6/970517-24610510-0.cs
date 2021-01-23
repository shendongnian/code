    Console.WriteLine("Please type a simple sum:");
    string sum = Console.Readline();
    var answer = new DataTable().Compute(sum, null);
    Console.WriteLine("{0} = {1}",sum, answer);
    Console.Readline();
