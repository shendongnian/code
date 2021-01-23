	public sealed class WorldMapCoord : IEquatable<WorldMapCoord>
	{
		private readonly int _X; 
		private readonly int _Y;
	
		public int X { get { return _X; } } 
		public int Y { get { return _Y; } }
	
		public WorldMapCoord(int X, int Y)
		{
			_X = X; 
			_Y = Y;    
		}
	
		public override bool Equals(object obj)
		{
			if (obj is WorldMapCoord)
					return Equals((WorldMapCoord)obj);
			return false;
		}
		
		public bool Equals(WorldMapCoord obj)
		{
			if (obj == null) return false;
			if (!EqualityComparer<int>.Default.Equals(_X, obj._X)) return false; 
			if (!EqualityComparer<int>.Default.Equals(_Y, obj._Y)) return false;    
			return true;
		}
		
		public override int GetHashCode()
		{
			int hash = 0;
			hash ^= EqualityComparer<int>.Default.GetHashCode(_X); 
			hash ^= EqualityComparer<int>.Default.GetHashCode(_Y);
			return hash;
		}
		
		public override string ToString()
		{
			return String.Format("{{ X = {0}, Y = {1} }}", _X, _Y);
		}
	}
