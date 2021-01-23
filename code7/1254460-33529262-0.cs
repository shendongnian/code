    var inner=csv1.Join(csv2,
        c1=>new {c1.ID,c1.SUBID},
        c2=>new {c2.ID,c2.SUBID},
        (c1,c2)=>new {c1,c2}).Where(c=>c.c1.Value!=c.c2.Value || Math.Abs(c1.QTY-c2.QTY)>1)
      .Select(c=>new {
        c2.ID,
        c2.SUBID,
        QTY=(c.c1.QTY==c.c2.Value)?null,c.c2.Value,
        Value=c.c1.Value==c.c2.Value?null,c.c2.Value);
