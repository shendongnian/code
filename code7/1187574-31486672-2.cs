		Func<string, HashSet<string>> split =
			x => new HashSet<string>(x.Split(
						new [] { '#' },
						StringSplitOptions.RemoveEmptyEntries));
		
        if (XAll.Any(x => split(S).IsSubsetOf(split(x))))
        {
            Console.WriteLine("Your String is exist");
        }
