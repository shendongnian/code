    class Anagrams
    {
        static void Main()
        {
    	// 1
    	// Read and sort dictionary
    	var d = Read();
    
    	// 2
    	// Read in user input and show anagrams
    	string line;
    	while ((line = Console.ReadLine()) != null)
    	{
    	    Show(d, line);
    	}
        }
    
        static Dictionary<string, string> Read()
        {
    	var d = new Dictionary<string, string>();
    	// Read each line
    	using (StreamReader r = new StreamReader("enable1.txt"))
    	{
    	    string line;
    	    while ((line = r.ReadLine()) != null)
    	    {
    		// Alphabetize the line for the key
    		// Then add to the value string
    		string a = Alphabetize(line);
    		string v;
    		if (d.TryGetValue(a, out v))
    		{
    		    d[a] = v + "," + line;
    		}
    		else
    		{
    		    d.Add(a, line);
    		}
    	    }
    	}
    	return d;
        }
    
        static string Alphabetize(string s)
        {
    	// Convert to char array, then sort and return
    	char[] a = s.ToCharArray();
    	Array.Sort(a);
    	return new string(a);
        }
    
        static void Show(Dictionary<string, string> d, string w)
        {
    	// Write value for alphabetized word
    	string v;
    	if (d.TryGetValue(Alphabetize(w), out v))
    	{
    	    Console.WriteLine(v);
    	}
    	else
    	{
    	    Console.WriteLine("-");
    	}
        }
    }
