    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	class Program
	{
		static void Main(string[] args)
		{
			List<string> list = new List<string>();
			list.Add("1");
			String text = "text";
			
			//Change Something In anotherText
			String anotherString = text;
			anotherString = "another String Changed";
			Console.WriteLine(text);
			
			//Change Something In anotherList
			List<string> anotherList = list;
			anotherList.Add("added in another List");
			foreach (var i in list)
			{
				Console.WriteLine(i);
			}
			
		}
	}
