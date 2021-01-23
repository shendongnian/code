using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{
	class MyClass
	{
		public MyClass(string a, string b)
		{
			A = a;
			B = b;
		}
		public string A	{ get; private set;	}
		public string B { get; private set; }
	}
	public static void Main()
	{
		var myData = new List<MyClass>();
		myData.Add(new MyClass("A1", "B1"));
		myData.Add(new MyClass("A2", "B2"));
		using (var writer = new System.IO.StreamWriter("myFile.txt"))
		{
			foreach (var row in myData)
			{
				string text = string.Format("{0},{1}", row.A, row.B);
				writer.WriteLine(text);
			}
		}
	}
 }
