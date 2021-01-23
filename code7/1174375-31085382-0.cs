    public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		string name = "asfd";
    		int plhp = 100, plmp = 100, zenhp = 500;
    		Random rdn = new Random();
    		int atk = rdn.Next(10, 55);
    		int zatk = rdn.Next(20, 35);
    		while (plhp > 0 && zenhp > 0)
    		{
    			string action = Console.ReadLine();
    			if (String.Equals(action, "attack", StringComparison.OrdinalIgnoreCase))
    			{
    				zenhp -= atk;
    				Console.WriteLine("Zen has taken -" + atk.ToString() + " damage!");
    				actionofzen(ref plhp, name, zenhp, zatk);
    				Console.WriteLine("Player HP: " +plhp);
    				Console.WriteLine("Zen HP: " +zenhp);
    				Console.WriteLine("Your next move?");
    				
    			}
    			else if (!(action == "attack"))
    			{
    				Console.WriteLine("Invalid command.");
    			}
    		}
    	}
    
    	public static int actionofzen(ref int plhp, string name, int zenhp, int zatk)
    	{
    		Random rdn = new Random();
    		string[] zenmoves =
    		{
    		"attack"
    		}
    
    		;
    		string zenaction = zenmoves[rdn.Next(zenmoves.Length)];
    		if (zenaction == "attack")
    		{
    			plhp -= zatk;
    			Console.WriteLine("Zen has countered, inflicting -" + zatk + " damage on " + name + ".");
    		}
    
    		return 0;
    	}
