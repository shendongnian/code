	public class KeyPublisher : Observable<ConsoleKeyInfo>
	{
	}
	public class PrintKeys : Observer<ConsoleKeyInfo>
	{
		public override void OnNext(ConsoleKeyInfo next)
		{
			if (next.Modifiers != 0)
				Console.Write("{0}-", next.Modifiers.ToString().Replace(", ", "-"));
			Console.WriteLine(next.Key);
		}
	}
	public class DetectEscape : Observer<ConsoleKeyInfo>
	{
		public bool FoundEscape { get; private set; }
		public override void OnNext(ConsoleKeyInfo next)
		{
			if (next.Key == ConsoleKey.Escape)
				FoundEscape = true;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var pub = new KeyPublisher();
			using (var sub1 = new PrintKeys())
			using (var sub2 = new DetectEscape())
			{
				sub1.SubscribeTo(pub);
				sub2.SubscribeTo(pub);
				while (!sub2.FoundEscape)
				{
					pub.Publish(Console.ReadKey(true));
				}
			}
		}
	}
