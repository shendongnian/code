    public static class JsonExtensions
    {
        public static string [] PropertyNames(this IContractResolver resolver, Type type)
        {
            if (resolver == null || type == null)
                throw new ArgumentNullException();
            var contract = resolver.ResolveContract(type) as JsonObjectContract;
            if (contract == null)
                return new string[0];
            return contract.Properties.Where(p => !p.Ignored).Select(p => p.PropertyName).ToArray();
        }
    }
