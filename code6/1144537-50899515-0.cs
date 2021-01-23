    public class ExcludeItemsOrderer : IBundleOrderer
    {
        private Func<BundleFile, bool>[] _excludes;
        public ExcludeItemsOrderer(params Func<BundleFile, bool>[] excludes)
        {
            _excludes = excludes;
        }
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            if(_excludes == null || _excludes.Length == 0)
            {
                return files;
            }
            foreach(var exclude in _excludes)
            {
                var exclusions = files.Where(exclude);
                files = files.Except(exclusions);
            }
            return files;
        }
    }
