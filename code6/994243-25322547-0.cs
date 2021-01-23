    list.Select(o => 
    	{
    		var pc = new ParentClass();
    		pc.ID = o.ID;
    		pc.ChildClass = o.Childs.Select(p => new ChildClass 
                { 
                    Parent = pc,
                    ID = p.id 
                }).ToList();
            return pc;
        });
