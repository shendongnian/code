    private int MyFunction(string name, int index)
    {
    	int score = name.AsEnumerable().Select(character => character - 96).Sum();
    	score *= index + 1;
    	return score;
    }
    
    int totalScore = File.ReadLines(@"c:/names.txt")
            .OrderBy(name => name)
            .Select(MyFunction)
            .Sum();
