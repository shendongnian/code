	public abstract class BaseClass<T>
	{
		protected string ProcessAdbCommand(string command)
		{
			return string.Empty;
		}
		
		public abstract T ProcessAdbOutput(string result);
	}
	
	public class DerivedClass : BaseClass<IList<IDevice>>
	{
		public override IList<IDevice> ProcessAdbOutput(string result)
		{
			return new List<IDevice>();
		}
	}
