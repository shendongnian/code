	public class A<T> {}
	
	public class B<T> : A<T> {}
	
	public class C : B<D> {}
	
	public class D {}
	
	public class Test
	{
		public static A<T> FactoryMethod<T>(int i)
	    {
	       if(i == 1)
	          return new A<T>();
	       if(i == 2)
	          return new B<T>();
	       if(i == 3)
	          return (A<T>)(object)new C();
	       return null;
	    }
	    
		public static void Main()
		{
			A<string> first = FactoryMethod<string>(1);
		 	A<int> second = FactoryMethod<int>(2);
	    	A<D> third = FactoryMethod<D>(3);
		}
	}
