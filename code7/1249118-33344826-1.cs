	public static void Main()
	{
		Console.WriteLine(Check("codewars", "code", "wasr")); //false
		Console.WriteLine(Check("codewars", "cod", "wars")); //false
		Console.WriteLine(Check("codewars", "cdwr", "oeas"));
		Console.WriteLine(Check("codewars", "code", "wars"));
		Console.WriteLine(Check("[W`meSnw(R1qaLLqc[=]=UAvTa_3%", "W`mnwqaLL]=va%", "[eS(R1qc[=UAT_3"));
		Console.WriteLine(Check("]ftUNn7-XoX4AZ3i1+", "U7oX4A1+", "]ftNn-XZ3i"));
        Console.WriteLine(Check("acab", "ab", "ac"));
	}
	
	private static bool Check(string s, string part1, string part2)
	{
		return CheckParts(s, part1, part2) || CheckParts(s, part2, part1);
	}
	private static bool CheckParts(string s, string part1, string part2)
	{
		var part1Index = 0;
		var part2Index = 0;
		foreach(var c in s)
		{
			if (part1Index < part1.Length && c == part1[part1Index])
			{
				//Console.WriteLine("c={0}, p1={1}", c, part1[part1Index]);
				part1Index++;
				continue;
			}
			if (part2Index < part2.Length && c == part2[part2Index])
			{
				//Console.WriteLine("c={0}, p2={1}", c, part2[part2Index]);
				part2Index++;
				continue;
			}
			return false;
		}
		return true;
	}
