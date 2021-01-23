    void Main()
    {
        var sampleMultiDelegate = new SampleMultiDelegate(SayHello);
        sampleMultiDelegate += SayGoodbye;
        var param1 = "Chiranjib";
        string param2;
        string result = "";
        foreach (var del in sampleMultiDelegate.GetInvocationList())
        {
            var f = (SampleMultiDelegate)del;
            f(param1, out param2);
            result += param2 + "\r\n";
        }
    
        Console.WriteLine(result);
    }
