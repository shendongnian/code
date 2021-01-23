    var result = (from wo in WorkOrderQuery
                  join s in ServiceQuery on wo.ServiceID equals s.ServiceID into g
                  from s in g.DefaultIfEmpty()
                  where wo.ServiceID == 0 || s != null
                  select new 
                  {
                      ServiceCode = s?.Code ?? string.Empty,
                      WorkOrderID = wo.WorkOrderID
                  }).ToList();
