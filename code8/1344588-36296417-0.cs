	public interface IApp {}
	
	public abstract class AppBase<T> : IApp where T : AppBase<T>, new()
	{
		public void Print()
		{
			Console.WriteLine(typeof(T).ToString());
		}
	}
	
	public class AppBaseFoo : AppBase<AppBaseFoo>
	{
	}
