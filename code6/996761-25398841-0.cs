	public class Parent
	{
		public int x;
		public Parent (int x)
		{
			this.x = x;
		}
		public override bool Equals(object o)
		{
			var p = o as Parent;
			if (object.Equals(p, null))
				return false;
			return this.x == p.x;
		}
		public override int GetHashCode()
		{
			return x;
		}
		public static bool operator ==(Parent a, Parent b)
		{
			return a.Equals (b);
		}
		public static bool operator !=(Parent a, Parent b)
		{
			return !(a == b);
		}
	}
	public class Child : Parent
	{
		public Child (int x)
			: base(x)
		{
			
		}
	}
	public class Gen<T> 
		where T : Parent 
	{
		public T variable;
	
		public Gen (T x)
		{
			this.variable = x;
		}
		public override bool Equals(object o)
		{
			var oT = o.GetType ().GetGenericTypeDefinition ();
			var tT = this.GetType ().GetGenericTypeDefinition ();
			if (tT != oT)
				return false;
			var oVar = o.GetType().GetField ("variable").GetValue (o);
			return this.variable.Equals (oVar);
		}
		public override int GetHashCode()
		{
			return variable.GetHashCode();
		}
		public static bool operator ==(Gen<T> a, object b)
		{
			return a.Equals (b);
		}
		public static bool operator !=(Gen<T> a, object b)
		{
			return !(a == b);
		}
	}
