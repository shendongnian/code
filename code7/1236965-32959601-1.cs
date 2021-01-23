    public class MyComparer : IEqualityComparer<List<PointF>>
    {
        public bool Equals(List<PointF> l1, List<PointF> l2)
        {
            //If lists contain different amount of items, they are different
    		if(l1.Count() != l2.Count()) return false;
    		
            //Order the lists by X then Y, that way we can compare them in order
    		var orderedL1 = l1.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
    		var orderedL2 = l2.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
    		
    		for(var i = 0; i < l1.Count(); i++)
    		{
    			if(orderedL1[i].X != orderedL2[i].X) return false;
    			if(orderedL1[i].Y != orderedL2[i].Y) return false;
    		}
    		//They must be the same if we reached here
    		return true;
        }
    
        public int GetHashCode(List<PointF> dp)
        {
    		return 0;
        }
    }
