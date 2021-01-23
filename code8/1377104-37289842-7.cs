	public class A
	{
		//...
	}
	public class B : A
	{
		//...
	}
	public interface I<T> where T : A
	{
		void test(T a);
	}
	public class C : I<B>
	{
		public void test(B b)
		{
		}
	}
