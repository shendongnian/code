    public static Dictionary<T,int> Distribute<T>( Dictionary<T,int> occurMap , int slots )
    {
        var freeSlots = slots -  occurMap.Count;
        var totalFreeSlots = freeSlots;
        var total = occurMap.Sum( x => x.Value );
        var distMap = new Dictionary<T,int>();
        var remainingSlots = new Dictionary<T,double>();
    
        foreach( var pair in occurMap )
        {
            var probability = (double)pair.Value / total;
            var assignedSlots = probability * totalFreeSlots;
            
            var integralPart = Math.Truncate(assignedSlots);
            var fractionalPart = assignedSlots - integralPart;                    
    
            distMap[ pair.Key ] = 1 + (int)integralPart;
            remainingSlots[pair.Key] = fractionalPart;
            freeSlots -= (int)integralPart;
        }   
        
        foreach (var pair in remainingSlots.ToList().OrderByDescending(x => x.Value))
        {
            if (freeSlots == 0)
                break;
            
            distMap[ pair.Key ]++;
            freeSlots -= 1;
        }             
    
        return distMap;
    }
