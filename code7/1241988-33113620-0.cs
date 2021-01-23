    var result = db.Claims
        .GroupBy(c => c.EditNumber)
        .Select(g => new {
            editNumber = g.FirstOrDefault().EditNumber,
            count = g.Count(),
            status = g.GroupBy(x => x.Status).Select(sg => new { 
                key = sg.FirstOrDefault().Status,
                count = sg.Count(),
            })
        }).ToList();
             
               
