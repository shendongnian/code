    void WhateverMethod() 
    {
        //tries to find a solution for a problem 3 times
        //in this process copies elements from old to newList
        foreach (var tryNbr in Util.range(0,3)) 
        {
            List<A> newList = new List<A>();
            List<A> oldList = workList;
            
            if (Matched(oldList, newList))
                continue;
            
            if(oldList.Any())
            {
                workList = newList;
                return true;
            }
        }
    }
    bool Matched(List<A> oldList, List<B> newList)
    {
       while(oldList.Count != 0)
        {
            List<A> possibleMatched = FINDWITHLINQSTUFF;
            //try stuff out
            if(possibleMatches.Count == 0)
                return false;
            //do more stuff
        }
        
        return true; // I'm assuming?
    }
