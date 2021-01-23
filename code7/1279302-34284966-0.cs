	public class Location : IEquatable<Location>
	{
		public bool Equals(Location other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(CodeTab, other.CodeTab) && Column == other.Column && Line == other.Line && Position == other.Position;
		}
		public static bool operator ==(Location left, Location right)
		{
			return Equals(left, right);
		}
		public static bool operator !=(Location left, Location right)
		{
			return !Equals(left, right);
		}
		public int Line { get; set; }
		public int Column { get; set; }
		public int Position { get; set; }
		public string CodeTab { get; set; }
		public Location(int line, int col, int pos, string tab)
		{
			Line = line;
			Column = col;
			Position = pos;
			CodeTab = tab;
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Location) obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (CodeTab != null ? CodeTab.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ Column;
				hashCode = (hashCode*397) ^ Line;
				hashCode = (hashCode*397) ^ Position;
				return hashCode;
			}
		}
	}
	
