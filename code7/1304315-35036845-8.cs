	var inStr = "time=value1 size=value2 dll=aDllName dll=anotherDllName, someParam=ParamValue dll=yetAnotherDll, someOhterParam=anotherParamValue aStandAloneValue dll=oneMoreDll, andItsParam=value anotherParam=value lastParam=value";
	
	bool isBeforeAnyDll = true;
	
	var result = inStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
		.Select(r => {
			var split = r.Split('=');
			if (split.Length == 1)
				return new { left = split[0], right = (string)null };
			
			var left = split[0];
			var right = split[1];
			return new { left, right };
		})
		.GroupAdjacentBy((l, r) =>  {
			return r.left == "dll" 
                 ? isBeforeAnyDll = false
			     : !isBeforeAnyDll;
		})
		.Select(g => string.Join(" ", 
			g.Select(gg => { 
				if (gg.right == null)
					return gg.left;
				return string.Format("{0}={1}", gg.left, gg.right);
			})));
    //https://stackoverflow.com/a/4682163/563532
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> GroupAdjacentBy<T>(
            this IEnumerable<T> source, Func<T, T, bool> predicate)
        {
            using (var e = source.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    var list = new List<T> { e.Current };
                    var pred = e.Current;
                    while (e.MoveNext())
                    {
                        if (predicate(pred, e.Current))
                        {
                            list.Add(e.Current);
                        }
                        else
                        {
                            yield return list;
                            list = new List<T> { e.Current };
                        }
                        pred = e.Current;
                    }
                    yield return list;
                }
            }
        }
    }
