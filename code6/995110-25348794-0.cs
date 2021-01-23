        public class MyCustomComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                var xIntValues = x.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var yIntValues = y.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            	
            	for(var i = 0; i < Math.Min(xIntValues.Count(), yIntValues.Count()); ++i)
            	    if (xIntValues[i] != yIntValues[i])
            	        return xIntValues[i] - yIntValues[i];
            	return xIntValues.Count() - yIntValues.Count();
            }
        }
		
