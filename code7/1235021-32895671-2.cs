	public interface I<T>
	{
		void Method(T t);
	}
	
	public abstract class Base<T> : I<T>
	{
                public Base(T t)
                {
                      this.param = t;
                }
                private readonly T param;
		public void Method()
		{
			// Do stuff
		}
	}
	
	public class A : Base<Folder>
	{
              public A(Folder folder) : base(folder)
              { }
	}
	
	public class B : Base<List>
	{
              public B(List list) : base(list)
              { }
	}
	
	public class Folder { }
	public class List { }
	
