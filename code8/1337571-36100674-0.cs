	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	namespace RegexReplaceTest
	{
		class Program
		{
			static void Main(string[] args)
			{
				string temp = "I love ***apple***, and also I love ***banana***.";
				//This is for replacing the values with specific value.
				string result = Regex.Replace(temp, @"\*\*\*[a-z]*\*\*\*", "Replacement", RegexOptions.IgnoreCase);
                Console.WriteLine("Replacement output:");
                Console.WriteLine(result);
				
				//This is for extracting the values
				Regex matchValues = new Regex(@"\*\*\*([a-z]*)\*\*\*", RegexOptions.IgnoreCase);
				MatchCollection matches = matchValues.Matches(temp);
				List<string> matchResult = new List<string>();
				foreach (Match match in matches)
				{
					matchResult.Add(match.Value);
				}
				Console.WriteLine("Values with *s:");
				Console.WriteLine(string.Join(",", matchResult));
				Console.WriteLine("Values without *s:");
				Console.WriteLine(string.Join(",", matchResult.Select(x => x.Trim('*'))));
			}
		}
	}
