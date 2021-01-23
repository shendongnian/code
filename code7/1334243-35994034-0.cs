	class Orange
	{
		public String color { get; set; }
		public override bool Equals(object obj)
		{
			var orange = obj as Orange;
			return Equals(orange);
		}
		protected bool Equals(Orange other)
		{
			return other != null && 
				string.Equals(color, other.color);
		}
		public override int GetHashCode()
		{
			return color?.GetHashCode() ?? 0;
		}
	}
