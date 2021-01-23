	abstract class Command
	{
		public abstract object GetValue();
	}
	class TalkCommand : Command
	{
		public override object GetValue()
		{
			return "Test";
		}
	}
	class SpendCommand : Command
	{
		public override object GetValue()
		{
			return 1234;
		}
	}
