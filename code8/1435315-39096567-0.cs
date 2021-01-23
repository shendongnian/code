    var result = from wo in WorkOrderQuery
                 from s in ServiceQuery.Where(x => wo.ServiceID == 0 || x.ServiceID == on wo.ServiceID).DefaultIfEmpty()
                  select new 
                  {
                     ServiceCode = s?.Code ?? string.Empty,
                     WorkOrderID = wo.WorkOrderID,
                  };
