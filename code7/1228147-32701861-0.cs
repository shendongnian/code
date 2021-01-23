    public static class EnumParser<T>
    {
        public static Parser<T> Create()
        {
            var names = Enum.GetNames(typeof(T));
    
            var parser = Parse.IgnoreCase(names.First()).Token()
                .Return((T)Enum.Parse(typeof(T), names.First()));
    
            foreach (var name in names.Skip(1))
            {
                parser = parser.Or(Parse.IgnoreCase(name).Token().Return((T)Enum.Parse(typeof(T), name)));
            }
    
            return parser;
        }
    }
