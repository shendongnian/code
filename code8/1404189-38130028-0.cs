    private string NOT_APPLICABLE = "N/A";
    . . .
    pvde.VarianceCraftworks = NOT_APPLICABLE;
    if (pvde.Week1PriceCraftworks.HasValue() && 
        pvde.Week2PriceCraftworks.HasValue())
    {
        pvde.VarianceCraftworks = 
            (string)(pvde.Week2PriceCraftworks.ToDecimal() - 
            pvde.Week1PriceCraftworks.ToDecimal());
    }
