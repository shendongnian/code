    public class Enemy
    {
        public int Priority;
    }
    public static void Main()
    {
        var rand = new Random();
        // Start with a sorted list of 10
        var enemies = Enumerable.Range(0, 10).Select(i => new Enemy() {Priority = rand.Next(0, 100)}).OrderBy(e => e.Priority).ToArray();
        // Insert random entries
        for (int i = 0; i < 100; i++)
            InsertEnemy(enemies, new Enemy() {Priority = rand.Next(100)});
    }
