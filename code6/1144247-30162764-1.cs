    void Main()
    {
        var alist = new List<A>();
        var blist = new List<B>();
    
        result = alist.GroupJoin(
            blist,
            a=>a.Id,	//Pick group key from A
            b=>b.Id,	//Pick group key from B
            (singleA,manyB)=>
                new{TheA=singleA,AllTheBs=manyB.ToList()}); //Create a resulting object.
    }
