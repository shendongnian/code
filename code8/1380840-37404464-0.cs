    gameAlbum[0] = new ComputerGame("Title 1", 1.99);
    gameAlbum[1] = new ComputerGame("Title 2", 1.99);
    gameAlbum[2] = new ComputerGame("Title 3", 1.99);
    
    foreach(ComputerGame o in gameAlbum)
    {
    	Console.WriteLine(o.title);
    }
