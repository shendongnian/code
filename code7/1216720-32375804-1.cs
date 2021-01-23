	public struct Pos : IEquatable<Pos>
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		public float Height { get; private set; }
		public Pos(int x, int y, float height)
		{
			X = x;
			Y = y;
			Height = height;
		}
		
		public bool Equals(Pos other)
		{
			return X == other.X && Y == other.Y;
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is Pos && Equals((Pos) obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}
		public static bool operator ==(Pos left, Pos right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(Pos left, Pos right)
		{
			return !left.Equals(right);
		}
	}
	
