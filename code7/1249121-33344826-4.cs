	public static void Main()
	{
		Console.WriteLine(Check("codewars", "code", "wasr")); //false
		Console.WriteLine(Check("codewars", "cod", "wars")); //false
		Console.WriteLine(Check("codewars", "cdwr", "oeas"));
		Console.WriteLine(Check("codewars", "code", "wars"));
		Console.WriteLine(Check("[W`meSnw(R1qaLLqc[=]=UAvTa_3%", "W`mnwqaLL]=va%", "[eS(R1qc[=UAT_3"));
		Console.WriteLine(Check("]ftUNn7-XoX4AZ3i1+", "U7oX4A1+", "]ftNn-XZ3i"));
		Console.WriteLine(Check("acab", "ab", "ac"));
		Console.WriteLine(Check("b]aDw- !oKJnOJ", "b]aDwoKJ", "- !nOJ"));
		Console.WriteLine(Check("codewars", "codewarss", "")); //false
		Console.WriteLine(Check("codewars", "", "")); //false
		Console.WriteLine(Check("codewars", "codewars", null));
		Console.WriteLine(Check("Bananas from Bahamas", "Bahas", "Bananas from am"));
	}
	private static bool Check(string s, string part1, string part2)
	{
		if (part1 == null)
			part1 = "";
		
		if (part2 == null)
			part2 = "";
		
		var part1Index = 0;
		var part2Index = 0;
		var bothMatch = "";
		
		foreach(var c in s)
		{
			if (part1Index < part1.Length && part2Index < part2.Length && part1[part1Index] == part2[part2Index])
			{
				//both matching so keep track until they stop matching
				bothMatch += c;
			}
			else if (bothMatch.Length > 0 && c == part1[part1Index])
			{
				// part2 doesn't match anymore so roll back its index
				part2Index -= bothMatch.Length;
				bothMatch = "";
			}
			else if (bothMatch.Length > 0 && c == part2[part2Index])
			{
				// part1 doesn't match anymore so roll back its index
				part1Index -= bothMatch.Length;
				bothMatch = "";
			}
			
			if (part1Index < part1.Length && c == part1[part1Index])
			{
				//Console.WriteLine("c={0}, p1={1}", c, part1[part1Index]);
				part1Index++;
				if (bothMatch.Length == 0)
					continue;
			}
			
			if (part2Index < part2.Length && c == part2[part2Index])
			{
				//Console.WriteLine("c={0}, p2={1}", c, part2[part2Index]);
				part2Index++;
				if (bothMatch.Length == 0)
					continue;
			}
			
			if (bothMatch.Length > 0)
				continue;
			
			//Console.WriteLine("c={0}, p1={1}, p2={2}, both={3}", c, part1[part1Index], part2[part2Index], bothMatch);
			return false;
		}
		return (part1Index == part1.Length) && (part2Index == part2.Length);
	}
