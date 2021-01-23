		Func<string, string[]> split =
			x => x.Split(new [] { '#' }, StringSplitOptions.RemoveEmptyEntries);
		
        if (XAll.Any(x => split(x).Intersect(split(S)).Count() == split(S).Count()))
        {
            Console.WriteLine("Your String is exist");
        }
