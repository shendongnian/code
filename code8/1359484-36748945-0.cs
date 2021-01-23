    var cart=new []{
    	new {ID= 10, isInventory= true, Pricing= 4},
    	new {ID= 10, isInventory= true, Pricing= 20},
    	new {ID= 10, isInventory= false, Pricing= 5},
    	new {ID= 10, isInventory= false, Pricing= 23},
    	new {ID= 74, isInventory= false, Pricing= 7}
    };
    
    var results=cart.GroupBy(c=>c.isInventory)
    	.SelectMany(grp1=>grp1.GroupBy(th=>th.ID),(grp1,grp2)=>new {grp1=grp1,grp2=grp2})
        .GroupBy(temp0=>temp0.grp1.Key,temp0=>temp0.grp2)
    	.Dump();
