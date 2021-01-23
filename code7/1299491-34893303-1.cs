	public sealed class Player : IEquatable<Player>
	{
		private readonly string _Name;
		private readonly string _Team;
		private readonly string _Position;
		private readonly int _HomeRuns;
		private readonly int _Rbi;
		private readonly double _BattingAverage;
	
		public string Name { get { return _Name; } }
		public string Team { get { return _Team; } }
		public string Position { get { return _Position; } }
		public int HomeRuns { get { return _HomeRuns; } }
		public int Rbi { get { return _Rbi; } }
		public double BattingAverage { get { return _BattingAverage; } }
	
		public Player(string Name, string Team, string Position, int HomeRuns, int Rbi, double BattingAverage)
		{
			_Name = Name;
			_Team = Team;
			_Position = Position;
			_HomeRuns = HomeRuns;
			_Rbi = Rbi;
			_BattingAverage = BattingAverage;
		}
	
		public override bool Equals(object obj)
		{
			if (obj is Player)
				return Equals((Player)obj);
			return false;
		}
	
		public bool Equals(Player obj)
		{
			if (obj == null) return false;
			if (!EqualityComparer<string>.Default.Equals(_Name, obj._Name)) return false;
			if (!EqualityComparer<string>.Default.Equals(_Team, obj._Team)) return false;
			if (!EqualityComparer<string>.Default.Equals(_Position, obj._Position)) return false;
			if (!EqualityComparer<int>.Default.Equals(_HomeRuns, obj._HomeRuns)) return false;
			if (!EqualityComparer<int>.Default.Equals(_Rbi, obj._Rbi)) return false;
			if (!EqualityComparer<double>.Default.Equals(_BattingAverage, obj._BattingAverage)) return false;
			return true;
		}
	
		public override int GetHashCode()
		{
			int hash = 0;
			hash ^= EqualityComparer<string>.Default.GetHashCode(_Name);
			hash ^= EqualityComparer<string>.Default.GetHashCode(_Team);
			hash ^= EqualityComparer<string>.Default.GetHashCode(_Position);
			hash ^= EqualityComparer<int>.Default.GetHashCode(_HomeRuns);
			hash ^= EqualityComparer<int>.Default.GetHashCode(_Rbi);
			hash ^= EqualityComparer<double>.Default.GetHashCode(_BattingAverage);
			return hash;
		}
	
		public override string ToString()
		{
			return String.Format("{{ Name = {0}, Team = {1}, Position = {2}, HomeRuns = {3}, Rbi = {4}, BattingAverage = {5} }}", _Name, _Team, _Position, _HomeRuns, _Rbi, _BattingAverage);
		}
	}
	
