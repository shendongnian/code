    using System;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			var typeName = "System.Collections.Generic.Dictionary`2[System.String,System.String]";
			var resolvedType = Type.GetType(typeName); 
			Console.WriteLine(resolvedType.FullName);
		}
	}
