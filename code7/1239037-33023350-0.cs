    obj1.FullOuterJoin(obj2, 
      a=>a.Id,
      b=>b.Id,
      (a,b,id)=>new {id=a.Id>b.Id?a.Id:b.Id,Items=a.Items.Union(b.Items)},
      new {id=-1, Items=new List<string>()}, //Default for left side
      new {id=-2, Items=new List<string>()});//Default for right side
