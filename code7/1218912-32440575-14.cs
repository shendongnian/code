    public IEnumerable<CultureInfo> ForRegion(RegionInfo regionInfo)
    {
        return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Where(c => CultureBelongsToRegion(c, regionInfo));
        }
        private static bool CultureBelongsToRegion(CultureInfo c, RegionInfo regionInfo)
        {
            return c.GetRegionName() == regionInfo.Name;
        }
    }
