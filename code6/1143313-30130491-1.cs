    var result=db.Table
      .GroupBy(r=>new {
          r.Date1,
          r.Date2,
          r.Date3,
          r.col1,
          r.col2,
          r.Rate1,
          r.Rate2,
          r.Rate3,
          r.product,
          r.comment},
      p=>new {
          p.Amount1,
          p.Amount2,
          p.Amount3},
      (key,vals)=>new {
          key.Date1,
          key.Date2,
          key.Date3,
          Amount1=vals.Sum(v=>v.Amount1),
          Amount2=vals.Sum(v=>v.Amount2),
          Amount3=vals.Sum(v=>v.Amount3),
          key.col1,
          key.col2,
          key.Rate1,
          key.Rate2,
          key.Rate3,
          key.product,
          key.comment}
          );
