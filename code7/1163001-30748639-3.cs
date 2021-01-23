    // the ID of the PricingIncrement with year 2015
    var pricingIncrementId thes.Session
         .QueryOver<PricingIncrement>()
         .Where(x => x.IncrementYear == 2015)
         .Take(1)
         .Select(x => x.ID)
         .SingleOrDefault<int?>();
    this.Session
       .EnableFilter("CollFilter")
       .SetParameter("pricingIncrementId", pricingIncrementId);
    // ... the star schema query could be executed here
