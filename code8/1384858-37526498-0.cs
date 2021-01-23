	abstract class Command<T>
	{
		public abstract T GetValue();
	}
	class TalkCommand : Command<string>
	{
		public override string GetValue()
		{
			return "Test";
		}
	}
	class SpendCommand : Command<int>
	{
		public override int GetValue()
		{
			return 1234;
		}
	}
