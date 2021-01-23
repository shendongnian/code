	using System.Diagnostics;
	namespace ConsoleApplication1
	{
		class Program
		{
			[Conditional ("NEVER_DEFINED")]
			[Conditional ("CODE_ANALYSIS")]
			static void Log(string message)
			{
				System.Console.WriteLine("Demo conditional message logging: " + message);
			}
			static void Main(string[] args)
			{
				string message = "Only log this when `NEVER_DEFINE` is #defined";
				Log(message);
				Method("other message");
			}
			static void Method(string messageToLog)
			{
				Log(messageToLog);
			}
		}
	}
