    static void Main(string[] args)
    {
    	ComputerGame cg1 = new ComputerGame("Age of Empires",49.99);
    	Console.WriteLine(cg1.title);
    
    	ComputerGame cg2 = new ComputerGame("Heroes and Generals", 30.00);
    	ComputerGame cg3 = new ComputerGame("Team Fortress 2", 19.50);
    	ComputerGame[] gameAlbum = new ComputerGame[5];
    
    	gameAlbum[0] = cg1;
    	gameAlbum[1] = cg2;
    	gameAlbum[2] = cg3;
    
    	foreach(ComputerGame o in gameAlbum)
    	{
    		if (o != null)
    		   Console.WriteLine(o.title);
    	}
        
        double total = gameAlbum.Where(g => g != null).Sum(g => g.price);
    }
