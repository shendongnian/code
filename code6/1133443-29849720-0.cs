    foreach (DataRow mainrow in CaseTable.Rows)
    {
        RegionName = mainrow.Field<string>("Region");
        DistrictName = mainrow.Field<string>("DistrictName");
        if ("Resolved".Equals(mainrow.Field<string>("CaseStatus"))
            DistrictResolvedCount++;
        DistrictcaseCount++;
    }
    if (DistrictcaseCount > 0)
         PercentageResolved = (DistrictResolvedCount / DistrictcaseCount) * 100;
    else // What to do if there are no cases? 
        // 100% or use a special value for "PercResolved" ?
        PercentageResolved = 1; // 100 %
    PercResolved = PercentageResolved.ToString() + "%";
    ReportTable.Rows.Add(
        RegionName, DistrictName, 
        DistrictcaseCount, DistrictResolvedCount,
        PercResolved);
    
