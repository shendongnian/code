	string s = @"hello my name is martin
    I am from Paris in France";
	var split = s.Split(new[] {" ", Environment.NewLine}, StringSplitOptions.None);
	string part1 = string.Concat(split.Take(3));
	string part2 = string.Join(" ", split.Skip(3));
	string joined = string.Format("{0} {1}", part1, part2);
