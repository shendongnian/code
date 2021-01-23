    public IEnumerable<CultureInfo> ForRegion(RegionInfo regionInfo)
    {
        return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Where(c => CultureBelongsToRegion(regionInfo, c));
    }
    private static bool CultureBelongsToRegion(RegionInfo regionInfo, CultureInfo c)
    {
        return c.GetRegionName() == regionInfo.Name;
    }
