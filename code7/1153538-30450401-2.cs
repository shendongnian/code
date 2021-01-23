    var objs = new List<Obj>(){
        new Obj 
        { 
            p = "1",
            u = "A",
            sD = new List<SD>() {new SD() { s = "1"}, new SD() { s = "2"}}
        },
        new Obj 
        { 
            p = "2",
            u = "A",
            sD = new List<SD>() {new SD() { s = "1"}}
        },
        new Obj 
        { 
            p = "1",
            u = "A",
            sD = new List<SD>() {new SD() { s = "2"}, new SD() { s = "3"}}
        }
    };
    
    var distinct = from obj in objs
                   group obj by new { obj.p } into g
                   select new Obj {
                       p = g.Key.p,
                       u = g.First().u, 
                       sD = g.SelectMany(i => i.sD).Distinct().ToList() 
                   };
