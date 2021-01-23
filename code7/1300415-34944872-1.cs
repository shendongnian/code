    void Main()
    {
        // Wrap your code in this using statement...
    	using (var outputCapture = new OutputCapture())
    	{
    		Console.Write("test");
    		Console.Write(".");
    		Console.WriteLine("..");
    		Console.Write("Second line");
    		// Now you can look in this exact copy of what you've been outputting.
            var stuff = outputCapture.Captured.ToString();
    	}
    }
