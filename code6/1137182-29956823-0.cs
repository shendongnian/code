    class RawDataNameResolver : ValueResolver<IEnumerable<RawData>, String>
    {
        private String _name;
        
        public RawDataNameResolver(String name)
        {
            _name = name;
        }
        
        protected override String ResolveCore(IEnumerable<RawData> source)
        {
            if (source != null)
            {
                var match = source.SingleOrDefault(x => x.Name == _name);
                if (match != null)
                {
                    return match.Value;
                }
            }
            return null;
        }
    }
