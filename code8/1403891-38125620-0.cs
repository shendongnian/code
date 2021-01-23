    private static string GetPropertyPathFromFunc(Func<dynamic, object> propertySelector)
    {
        var collector = new PropertyNameCollector();
        propertySelector(collector);
        return collector.Name;
    }
    private class PropertyNameCollector : DynamicObject
    {
        public string Name { get; private set; }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!string.IsNullOrEmpty(Name))
                Name += ".";
            Name += binder.Name;
            result = this;
            return true;
        }
    }
