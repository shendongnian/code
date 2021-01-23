    var minMaxInfo = minMaxList.Skip(1)
        .Aggregate(
            new
		    { 
		        Max = new int[] { minMaxList[0].Max },
		        MaxIndexes = new List<int> { 0 },
		        Min = new int[] { minMaxList[0].Min },
		        MinIndexes = new List<int> { 0 },
		        Index = new int[] { 0 }
		    },
            (r, t) =>
		    {
		        r.Index[0]++;    	
		        if (t.Min < r.Min[0])
		        {
		            r.Min[0] = t.Min;
		            r.MinIndexes.Clear();
		            r.MinIndexes.Add(r.Index[0]);
		        } 
		        else if (t.Min == r.Min[0])
		        {
		            r.MinIndexes.Add(r.Index[0]);	
		        }
		
		        if (t.Max > r.Max[0])
		        {
		            r.Max[0] = t.Max;
		            r.MaxIndexes.Clear();
		            r.MaxIndexes.Add(r.Index[0]);
		        }
		        else if (t.Max == r.Max[0])
		        {
		           r.MaxIndexes.Add(r.Index[0]);
		        }
		
		        return r;
		    });
