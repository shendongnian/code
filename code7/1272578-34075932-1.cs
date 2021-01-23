	public class StringTriplet
	{
		private List<string> Store;
		// accessors:
		public string A { get; private set; }
		public string B { get; private set; }
		public string C { get; private set; }
		// constructor
		public StringTriplet(string a, string b, string c)
		{
			this.Store = new List<string>();
			this.Store.Add(a);
			this.Store.Add(b);
			this.Store.Add(c);
			this.Store.Sort();
			this.A = a;
			this.B = b;
			this.C = c;
		}
		public int CompareTo(StringTriplet obj)
		{
			if (null == obj)
				return -1;
			int cmp;
			cmp = this.Store.Count.CompareTo(obj.Store.Count);
			if (0 != cmp)
				return cmp;
			for (int i = 0; i < this.Store.Count; i++)
			{
				if (null == this.Store[i])
					return 1;
				cmp = this.Store[i].CompareTo(obj.Store[i]);
				if ( 0 != cmp )
					return cmp;
			}
			return 0;
		}
		override public bool Equals(object obj)
		{
			if (! (obj is StringTriplet))
				return false;
			var t = obj as StringTriplet;
			return ( 0 == this.CompareTo(t));
		}
		public override int GetHashCode()
		{
			int res = 0;
			for (int i = 0; i < this.Store.Count; i++)
				res = res ^ (null == this.Store[i] ? 0 : this.Store[i].GetHashCode()) ^ i;
			return res;
		}
	}
