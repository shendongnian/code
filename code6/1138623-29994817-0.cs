    // I am assuming LoanAgent is the one you want to filter on
    // and it has an Id property.
    var forLoanAgentId = LoanAgent.Id;
    // I am assuming a Pricing has a DateTime field
    // named "PricedOn"
    var result = 
        from lead in WebLeads
        where lead.LoanAgent.Id == forLoanAgentId && lead.LeadStatus == "Priced"
        select new {
            Lead = lead,
            LastPricing = lead.Pricings.OrderByDescending(x => x.PricedOn).FirstOrDefault()
        };
 
