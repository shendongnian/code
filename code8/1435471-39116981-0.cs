    var Query = from P in flightsPricingRulesContext.ServiceFee
    .Include(sf =>   sf.ServiceFeeCarrier)
    .Include(sf=>sf.ServiceFeeAssignment)
    .Include(sf => sf.ServiceFeeClassOfService)
    .Include(sf => sf.ServiceFeeDate)
    .Include(sf => sf.ServiceFeeMarkUpAssignment)
    .Include(sf => sf.ServiceFeeZone.Select(zo => zo.Zone))
    .AsExpandable().Where(filter) select P;
