    public class Player
	{
		public string Name { get; set; }
		public int Score { get; set; }
		public Player(string name)
		{
			Name = name;
		}
	}
	public class Players : List<Player>
	{
		public void SortByScore()
		{
			Sort((a, b) => a.Score.CompareTo(b.Score));
		}
		public void SortByName()
		{
			Sort((a, b) => a.Name.CompareTo(b.Name));
		}
	}
