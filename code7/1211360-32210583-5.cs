	using System;
	public class Program
	{
		// Properties you want others to have access too
		public interface ICredentialsValidator
		{
			bool IsTest(string userName);
		}
		public static void Main()
		{
			var b = new PublicClass().GetCredentialsValidator();
			Console.WriteLine(b.IsTest("test"));
			Console.WriteLine(b.IsTest("blah"));
		}
		public class PublicClass
		{
			public ICredentialsValidator GetCredentialsValidator()
			{
				return new PrivateClass();
			}
			private class PrivateClass : ICredentialsValidator
			{
				public bool IsTest (string userName)
				{
					return userName == "test";
				}
			}
		}
	}
