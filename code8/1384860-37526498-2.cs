	abstract class Command
	{
		public abstract object GetValue();
	}
	abstract class Command<T> : Command
	{
		public T GetTypedValue()
		{
			return (T)GetValue();
		}
	}	
	class TalkCommand : Command<string>
	{
		public override object GetValue()
		{
			return "Test";
		}
	}
	class SpendCommand : Command<int>
	{
		public override object GetValue()
		{
			return 1234;
		}
	}
