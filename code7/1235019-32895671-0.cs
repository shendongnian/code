	public interface I<T>
	{
		void Method(T t);
	}
	
	public abstract class Base<T> : I<T>
	{
		public void Method(T t)
		{
			// Do stuff
		}
	}
	
	public class A : Base<Folder>
	{
	}
	
	public class B : Base<List>
	{
	}
	
	public class Folder { }
	public class List { }
	
