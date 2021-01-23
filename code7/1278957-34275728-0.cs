    static void Main()
    {
        int a = 1;
        int b = 4;
        // a and b are passed in as arguments to the function
        var sum = new Command<int>(args => (int)args[0] + (int)args[1], a, b);
        // a and b are captured by the function
        var sum2 = new Command<int>(_ =>
        {
            var c = a + b;
            a++;
            b++;
            
            return c;
        });
        Console.WriteLine(sum.Execute()); //Prints out 5
        Console.WriteLine(sum2.Execute()); //Prints out 5
        Console.WriteLine("a = " + a); // Prints 2
        Console.WriteLine("b = " + b); // Prints 5
        Console.ReadLine();
    }
