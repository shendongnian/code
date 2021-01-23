    enum Name
    {
    	Kumar = 1,
    	Raju = 2,
    	Anil = 3,
    	Suresh = 4,
    	Bhaskar = 5,
    	Chandra = 6
    };
    
    public static void Main()
    {
    	var itemNames = System.Enum.GetNames(typeof(Name))
    							   .OrderBy(o => (string)o == "Bhaskar" ? 1 : 0)
    							   .ToArray(); 
    	for (int i = 0; i <= itemNames.Length - 1 ; i++) 
    	{
    		Console.WriteLine((string)itemNames[i]);
    	}
    }
