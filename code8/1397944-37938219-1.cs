    public class objA
    {
        public int foo1{ get; set; }
        public string foo2 { get; set; }
        public bool foo3 { get; set; }
		public override bool Equals(object obj)
		{
			if (obj is objA == false) return false;
			var a = (objA)obj;
			return a.foo1 == foo1
				&& a.foo2 == foo2
				&& a.foo3 == foo3;
		}
		public override int GetHashCode()
		{
			return foo1.GetHashCode()
				^ foo2.GetHashCode()
				^ foo3.GetHashCode();
		}
    }
