    void Main()
    {
    	string input = "Classic-T50 (Black Grey)";
    	StringBuilder inputsb = new StringBuilder(input);
    	Console.WriteLine(input);
    	inputsb[18] = '+';
    	Console.WriteLine(inputsb.ToString());
    }
