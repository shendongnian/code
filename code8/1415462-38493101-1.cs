    public class Program
    {
        private static Player player;
    
        public static void method2()
        {
            string[] lines = { "Stat 1", "Stat 2", "Stat 3" };
             System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
             Process.Start(@"C:\Users\Public\TestFolder\WriteLines.txt");
        }
    
        public static void Main(string[] args)
        {
             player = new Player();
             player.health = 20;
             
             method2(player);
        }
    }
