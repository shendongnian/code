     var v = (from pd in ge.Costs
                     join od in ge.Services on pd.ServiceId equals od.ServiceId
                     join ct in ge.ServiceTypes on pd.ServiceTypeId equals ct.ServiceTypeId
                     where pd.ServiceTypeId.Equals(2)
                   select new costViewModel()
                   {
                       CostId = pd.CostId,
                       serviceName = od.serviceName,
                       ServiceTypeValue = ct.ServiceTypeValue,
                       ServiceCost = pd.ServiceCost
                   }).ToList();
    view(v);
