    // declaring a lambda fn because it's gonna be used by both include/exclude   
    // list
    Func<string, IEnumerable<int>> rangeFn = 
        baseInput =>
		{
		    return baseInput.Split (new []{ ',', ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
				.SelectMany (rng => 
                    {
					    var range = rng.Split (new []{ '-' }, 
                            StringSplitOptions.RemoveEmptyEntries)
                            .Select(i => Convert.ToInt32(i));
                        // just in case someone types in
                        // a reverse range (e.g. 10-5), LOL...
						var start = range.Min ();
						var end = range.Max ();
						return Enumerable.Range (start, (end - start + 1));
					});
			};
    var includes = rangeFn (includesRaw);
	var excludes = rangeFn (excludesRaw);
	var result = includes.Except (excludes).Distinct().OrderBy(r => r);
