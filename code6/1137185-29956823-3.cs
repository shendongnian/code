    class RawDataNameResolver : ValueResolver<IEnumerable<RawData>, String>
    {
        private String _name;
        private Func<String, String> _postProcessor;
        
        public RawDataNameResolver(String name, Func<String, String> postProcessor = null)
        {
            _name = name;
            _postProcessor = postProcessor;
        }
        
        protected override String ResolveCore(IEnumerable<RawData> source)
        {
            if (source != null)
            {
                var match = source.SingleOrDefault(x => x.Name == _name);
                if (match != null)
                {
                    return _postProcessor != null ? _postProcessor(match.Value) : match.Value;
                }
            }
            return null;
        }
    }
