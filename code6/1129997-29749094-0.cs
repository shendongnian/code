    var records = (from o in _context.Table1
                   join q in _context.Table2 on o.UserId equals q.UserId
                   group new { o, q }
                   by new 
                   { 
                       o.Name, 
                       o.Date,  
                       o.IsDone,  
                       o.IsDl,  
                       o.DateChanged,  
                       o.UserId,  
                       q.FirstName,  
                       q.LastName  
                   } into data
                   select new
                   {
                       NameP = data.Key.Name,
                       Date = data.Key.Date,
                       IsDone = data.Key.IsDone,
                       IsDl = data.Key.IsDl,
                       DateDone = data.Key.DateChanged,
                       Name = data.Key.FirstName +" "+ data.Key.LastName
                   }).Union(from i in _context.Table1
                            where i.UserId == null
                            group i by new 
                            {
                                o.Name,
                                o.Date, 
                                o.IsDone, 
                                o.IsDl, 
                                o.DateChanged, 
                                o.UserId
                            } into newData
                            select new
                            {
                                NameP = newData.Key.Name,
                                Date = newData.Key.Date,
                                IsDone = newData.Key.IsDone,
                                IsDl = newData.Key.IsDl,
                                DateDone = new DateTime(0),
                                Name = ' '
                            }).ToList();
