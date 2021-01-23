    static void Main(string[] args) {
    	Dictionary<char, bool> charsEntered = new Dictionary<char, bool>();
    
    	Console.WriteLine("Please enter 5 characters, each on a separate line.");
    	while (charsEntered.Count() < 5) {
    		Console.WriteLine("Enter a character:");
    		char[] resultChars = Console.ReadLine().ToCharArray();
    
    		if(resultChars.Length != 1 || !Char.IsLetter(resultChars[0])) {
    			Console.WriteLine("Bad Entry. Try again.");
    		} else {
    			char charEntered = resultChars[0];
    			if (charsEntered.ContainsKey(charEntered))
    				Console.WriteLine("Character already encountered. Try again.");
    			else
    				charsEntered[charEntered] = true;
    		}
    	}
    
    	Console.WriteLine("The following inputs were entered:");
    	Console.WriteLine(String.Join(", ", charsEntered.Keys));
    	Console.ReadLine();
    }
