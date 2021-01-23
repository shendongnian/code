    using System;
    
    class Program
    {
    	public static void Main(string[] args)
    	{
    		string question1 = "What is your name? ";
    		string question2 = "How old are you? ";
    		
    		// first question
    		Console.Write(question1);
    		string name = Console.ReadLine();
    		
    		// second question
    		Console.SetCursorPosition(question1.Length + name.Length + 1, 0);
    		Console.Write(question2);
    		string age = Console.ReadLine();
    		
    		// print output
    		Console.WriteLine("Hello {0}, your age is {1}", name, age);
    		
    		Console.Write("Press any key to continue . . . ");
    		Console.ReadKey(true);
    	}
    }
