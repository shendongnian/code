    static void Main(string[] args)
    {
        ComputerGame[] gameAlbum = new ComputerGame[3];
    
        gameAlbum[0] = new ComputerGame("Age of Empires",49.99);
        gameAlbum[1] = new ComputerGame("Heroes and Generals", 30.00);
        gameAlbum[2] = new ComputerGame("Team Fortress 2", 19.50);
    
        foreach(ComputerGame o in gameAlbum)
        {
    	   Console.WriteLine(o.title);
        }
    }
    
    public class ComputerGame
    {
        public string title;
        public double price;
        public ComputerGame(string title, double price)
        {
            this.title = title;
            this.price = price;
    
        }
    }
