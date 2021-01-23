	namespace ConsoleApplication1
	{
		using System;
		using System.Linq;
		class Program
		{
			public enum ImportState : byte
			{
				None = 0,
				ImportedWithChanges = 44,
				AwaitingApproval = 45,
				Removing = 66,
				Revalidating = 99,
			}
			static void Main(string[] args)
			{
				Console.WriteLine(GetOrder(ImportState.None));
				Console.WriteLine(GetOrder(ImportState.AwaitingApproval));
			}
			public static int GetOrder(ImportState state)
			{
				var enumValues = Enum.GetValues(typeof(ImportState)).Cast<ImportState>().ToList();
				return enumValues.IndexOf(state) + 1; // +1 as the IndexOf() is zero-based
			}
		}
	}
----------
    1
    3
    Press any key to continue . . .
