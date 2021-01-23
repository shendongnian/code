    var query = from mmud in context.updateData 
                from mmudkv in context.updateDataKeyValue
                                      .Where(x => mmud.updateDataid == x.updateDataId)
                                      .DefaultIfEmpty()
                from mmuddk in context.updateDataDetailKey 
                                      .Where(x => mmudkv.updateDataDetailKeyid == x.Id)
                                      .DefaultIfEmpty()
                where mmud.dbname == "MY_NEW_DB"
                where mmudkv.value == "start" ||  mmudkv.value == "finish"
                group mmud by mmud.logDateTime.Date into g
                select new 
                {
                   Date = g.Key,
                   Average = EntityFunctions.DiffMilliseconds(g.Max(x => x.logDateTime), g.Min(x => x.logDateTime)),
                };
    var queryByMonth = from x in query
                       group x by new { x.Date.Year, x.Date.Month } into x
                       select new
                       {
                         Year = x.Key.Year,
                         Month = x.Key.Month,
                         Average = x.Average(y => y.Average)
                       };
               
    // Single sql statement is to sent to your database
    var result = queryByMonth.ToList();
