	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	namespace Test1
	{
		class Program
		{
			static void Main(string[] args)
			{
				var myVarName = "test";
				myVarName.Test();
				Console.ReadKey();
			}
		}
		static class Extensions
		{
			public static void Test(this string str, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
			[System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
			[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
			{
				var relevantLine = File.ReadAllLines(sourceFilePath)[sourceLineNumber-1];
				var currMethodName = MethodInfo.GetCurrentMethod().Name;
				var callIndex = relevantLine.IndexOf(currMethodName + "()");
				var sb = new Stack<char>();
				for (var i = callIndex - 2; i >= 0; --i)
				{
					if (char.IsLetterOrDigit(relevantLine[i]))
						sb.Push(relevantLine[i]);
					
				}
				Console.WriteLine(new string(sb.ToArray()));
			}
		}
	}
