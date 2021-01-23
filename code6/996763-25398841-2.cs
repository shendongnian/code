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
            if (object.Equal(o, null)) return false;
            // CAUTION: VERY DIRTY - just a quick reply to hvd - should check/remove this with test cases!
            try
            {
			   var oT = o.GetType ().GetGenericTypeDefinition ();
			   var tT = this.GetType ().GetGenericTypeDefinition ();
			   if (tT != oT)
				   return false;
               // for example this:
			   // var oVar = o.GetType().GetField ("variable").GetValue (o);
               // should really be
               var varField = o.GetType().GetField("variable");
               if (varField == null) return;
               var oVar = varField.GetValue(o);
               if (object.Equals(oVar, null)) 
                  return object.Equals(this.variable, null);
			   return this.variable.Equals (oVar);
             } catch { return false; }
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
