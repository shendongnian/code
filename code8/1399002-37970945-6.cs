    using System;
    using System.Text.RegularExpressions;
    
	
	public class Program
	{
		public static void Main()
		{
			String test = "this is a @test & when ist asd*sd";
			
			Match match = Regex.Match(test, "([@&\\*])");
			
			int i = 0;
			while (match.Success)
			{
				Console.WriteLine("Index of Match Nr."+ i.ToString()
						          + " (char "+ match.Value +"): "
						          + match.Index.ToString());
				match = match.NextMatch();
				i++;
			}
		}
	}
