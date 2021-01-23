    var serviceId = ...;
    
    var partners = dbContext.Services
          .Where(svc => svc.Id == serviceId || (serviceId == 1 && svc.Id == 5))
          .SelectMany(svc => svc.PartnerServiceBrands)
          .Select(psb => psb.Partner).Distinct();
