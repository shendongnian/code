    public static class EnumExtensions
    {
        private static readonly ConcurrentDictionary<Type, DescriptionCache> Caches = new ConcurrentDictionary<Type, DescriptionCache>();
        public static string GetDescription(this Enum value, string key)
        {
            var enumType = value.GetType();
            var cache = Caches.GetOrAdd(enumType, type => new DescriptionCache(type));
            return cache.GetDescription(value, key);
        }
        public static IEnumerable<TEnum> GetValuesFromDescription<TEnum>(string key, string description)
            where TEnum : struct
        {
            var cache = Caches.GetOrAdd(typeof(TEnum), type => new DescriptionCache(type));
            return cache.GetValues(key, description).Select(value => (TEnum)(object)value);
        }
        private class DescriptionCache
        {
            private readonly ILookup<Enum, Tuple<string, string>> _items;
            private readonly ILookup<Tuple<string, string>, Enum> _reverse;
            public DescriptionCache(Type enumType)
            {
                if (!enumType.IsEnum)
                    throw new ArgumentException("Not an enum");
                _items = (from value in Enum.GetValues(enumType).Cast<Enum>()
                          let field = enumType.GetField(value.ToString())
                          where field != null
                          from attribute in field.GetCustomAttributes(typeof (DescriptionEntryAttribute), false).OfType<DescriptionEntryAttribute>()
                          select new {value, key = attribute.Key, description = attribute.Value})
                    .ToLookup(i => i.value, i => Tuple.Create(i.key, i.description));
                _reverse = (from grp in _items
                            from description in grp
                            select new {value = grp.Key, description})
                    .ToLookup(i => i.description, i => i.value);
            }
            public string GetDescription(Enum value, string key)
            {
                var tuple = _items[value].FirstOrDefault(i => i.Item1 == key);
                return tuple != null ? tuple.Item2 : null;
            }
            public IEnumerable<Enum> GetValues(string key, string description)
            {
                return _reverse[Tuple.Create(key, description)];
            }
        }
    }
