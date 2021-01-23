    public static string[] SplitItem(string[] input, int index)
    {
    	var l = new List<string>(input.Length);
    	l.AddRange(input.Take(index));
    	l.AddRange(Regex.Split(input[index], @"\s{1,}").Where(y => !string.IsNullOrEmpty(y)));
    	l.AddRange(input.Skip(index + 1).TakeWhile(x => true));
    	return l.ToArray();
    }
	var word = new string[3];
	word[0] = "Listen Repeat";
	word[1] = "Tune";
	word[2] = "Landing Page";
	word = SplitItem(word,0);
