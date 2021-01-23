    using System;
						
	public class Program
	{
		public static void Main()
		{
			var b = new class1().GetCredentialsValidator("test");
			
			Console.WriteLine(b.IsTest);
		}
		
		// Properties you want others to have access too
		public interface ICredentialsValidator
		{
			bool IsTest { get; }
		}
		
		public class class1
		{
			public ICredentialsValidator GetCredentialsValidator(string a)
			{
				return new class2(a);
			}
			
			
			private class class2 : ICredentialsValidator
			{
				public class2(string user)
				{
					IsTest = user == "test";
				}
				
				public bool IsTest  { get; set; }
			}
		}
	}
