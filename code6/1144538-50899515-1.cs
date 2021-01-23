    public static class BundleExtensions
    {
        public static Bundle AsIsOrderExcluding(this Bundle bundle, params Func<BundleFile, bool>[] excludes)
        {
            bundle.Orderer = new ExcludeItemsOrderer(excludes);
            return bundle;
        }
    }
