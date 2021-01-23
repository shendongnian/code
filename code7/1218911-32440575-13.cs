    public static class CultureInfoExtension
    {
        private static readonly Dictionary<int, string> RegionNamesByLcid =
            CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(c => c.LCID)
                .Distinct()
                .ToDictionary(lcid => lcid, lcid => new RegionInfo(lcid).Name);
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
