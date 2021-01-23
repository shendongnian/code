    Random rnd = new Random(10000);
    //OP's Solution 2
	public String RollRegex() {
		int roll = rnd.Next(1, 100000);
		if (Regex.IsMatch(roll.ToString(), @"(.)\1{1,}$")) {
			return "doubles";
		} else {
			return "none";
		}
	}
    //Radin Gospodinov's Solution
	Regex optionRegex = new Regex(@"(.)\1{1,}$", RegexOptions.Compiled);
	public String RollOptionRegex() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();			
		if (optionRegex.IsMatch(roll.ToString())) {
			return "doubles";
		} else {
			return "none";
		}
	}
    //OP's Solution 1
	public String RollEndsWith() {
		int roll = rnd.Next(1, 100000);
		if (roll.ToString().EndsWith("11") || roll.ToString().EndsWith("22") || roll.ToString().EndsWith("33") || roll.ToString().EndsWith("44") || roll.ToString().EndsWith("55") || roll.ToString().EndsWith("66") || roll.ToString().EndsWith("77") || roll.ToString().EndsWith("88") || roll.ToString().EndsWith("99") || roll.ToString().EndsWith("00")) {
			return "doubles";
		} else {
			return "none";
		}
	}
    //My Solution	
	public String RollSimple() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();
		return roll > 10 && rollString[rollString.Length - 1] == rollString[rollString.Length - 2] ?
			"doubles" : "none";
	}
    //My Other Solution
	List<string> doubles = new List<string>() { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
	public String RollAnotherSimple() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();
		return rollString.Length > 1 && doubles.Contains(rollString.Substring(rollString.Length - 2)) ?
			"doubles" : "none";
	}
    //Dandré's Solution
	HashSet<string> doublesHashset = new HashSet<string>() { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
	public String RollSimpleHashSet() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();
		return rollString.Length > 1 && doublesHashset.Contains(rollString.Substring(rollString.Length - 2)) ?
			"doubles" : "none";
	}
    //Corak's Solution - hinted by Alexei Levenkov too
	public string RollModded() { int roll = rnd.Next(1, 100000); return roll % 100 % 11 == 0 ? "doubles" : "none"; }
    //Stian Standahl optimizes modded solution
	public string RollOptimizedModded() { return rnd.Next(1, 100000) % 100 % 11 == 0 ? "doubles" : "none"; }
	//Gjermund Grøneng's method with constant addition
	private const string CONST_DOUBLES = "doubles";
	private const string CONST_NONE = "none";
	public string RollOptimizedModdedConst() { return rnd.Next(1, 100000) % 100 % 11 == 0 ? CONST_DOUBLES : CONST_NONE; }
	//Gjermund Grøneng's method after optimizing the Random (The fastest!)
	public string FastestOptimizedModded() { return (rnd.Next(99999) + 1) % 100 % 11 == 0 ? CONST_DOUBLES : CONST_NONE; }
	//Corak's Solution, added on Gjermund Grøneng's
	private readonly string[] Lookup = { "doubles", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none" }; 
	public string RollLookupOptimizedModded() { return Lookup[(rnd.Next(99999) + 1) % 100 % 11]; }
