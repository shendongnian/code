	void Main()
	{
		var game = new Game();
		game.CreateEnemy("Blinky");
		Console.WriteLine(game.EnemyCount);
		game.CreateEnemy("Clyde");
		Console.WriteLine(game.EnemyCount);
		game.DestroyEnemy(game.Enemies[0]);
		Console.WriteLine(game.EnemyCount);
	}
	
	public class Game
	{
		public List<Enemy> Enemies = new List<Enemy>();
	
		public void CreateEnemy(string name)
		{
            if (EnemyCount >= MAX_ENEMIES) return;
			var enemy = new Enemy { Name = name};
			Enemies.Add(enemy);
		}
	
		public void DestroyEnemy(Enemy enemy)
		{
			Enemies.Remove(enemy);
		}
	
		public int EnemyCount
		{
			get { return Enemies.Count(); }
		}
	}
	
	public class Enemy
	{
		public string Name { get; set; }
	}
