    if (!IsNullData(priceAndUsageVarianceRow["Description"]))
    {
        pauv.Description = priceAndUsageVarianceRow["Description"].ToString();
    }
    if (!IsNullData(priceAndUsageVarianceRow["Week1Usage"]))
    {
        pauv.Week1Usage = Convert.ToDouble(priceAndUsageVarianceRow["Week1Usage"]);
    }
    if (!IsNullData(priceAndUsageVarianceRow["Week2Usage"]))
    {
        pauv.Week2Usage = Convert.ToDouble(priceAndUsageVarianceRow["Week2Usage"]);
    }
