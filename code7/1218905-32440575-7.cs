    public static class CultureInfoExtension
    {
        private static readonly Dictionary<int, string> RegionNamesByLcid =
            CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .GroupBy(c => c.LCID)
                .ToDictionary(c => c.Key, c => new RegionInfo(c.Key).Name);
        private static string FallbackToThrowConsistentException(CultureInfo c)
        {
            return new RegionInfo(c.LCID).Name;
        }
        public static string GetRegionName(this CultureInfo c)
        {
            string name;
            return RegionNamesByLcid.TryGetValue(c.LCID, out name)
                ? name
                : FallbackToThrowConsistentException(c);
        }
    }
