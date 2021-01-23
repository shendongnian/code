    public static class JsonExtensions
    {
        public static IEnumerable<string> PropertyNames(this IContractResolver resolver, Type type)
        {
            if (resolver == null || type == null)
                throw new ArgumentNullException();
            var contract = resolver.ResolveContract(type) as JsonObjectContract;
            if (contract == null)
                return Enumerable.Empty<string>();
            return contract.Properties.Where(p => !p.Ignored && p.Readable).Select(p => p.PropertyName);
        }
    }
