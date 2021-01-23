	using System;
	using System.Reflection;
	namespace MyNamespace
	{
		public static class MovingAverage
		{
			public static double MyMethod(int Period, int CurrentBar, int[] Input, int[] average)
			{
				return 5;
			}
		}
		class Program
		{
			static void Main(string[] args)
			{
				var arguments = new object[] { 1, 2, new[] { 2 }, new[] { 4 } };
				Console.WriteLine(GetValueOfAverage("MyNamespace.MovingAverage", "MyMethod", arguments)); //if assembly is already loaded
				Console.WriteLine(GetValueOfAverage("MyNamespace.MovingAverage, ConsoleApplication1", "MyMethod", arguments)); //if assembly is not loaded yet
				Console.WriteLine(GetValueOfAverage(typeof(MovingAverage), "MyMethod", arguments)); //known type
				Console.ReadKey();
			}
			public static double GetValueOfAverage(string typeName, string methodName, object[] arguments)
			{
				// ... get the Type for the class
				Type calledType = Type.GetType(typeName, true);
				return GetValueOfAverage(calledType, methodName, arguments);
			}
			public static double GetValueOfAverage(Type calledType, string methodName, object[] arguments)
			{
				double avg = (double)calledType.InvokeMember(
							   methodName,
							   BindingFlags.InvokeMethod | BindingFlags.Public |
							   BindingFlags.Static | BindingFlags.NonPublic,
							   null,
							   null,
							   arguments);
				// Return the value returned by the called method.
				return avg;
			}
		}
	}
