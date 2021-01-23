    class Program
    {
        static void Main(string[] args)
        {
            Parse(args[1]);
        }
        static void Parse(string type)
        {
            var parserType = typeof(BaseParser<>)
                .Assembly // or whatever the assembly is
                .GetTypes()
                .First(t => t.BaseType?.GetGenericArguments().FirstOrDefault() == typeInfos[type]);
            dynamic parser = Activator.CreateInstance(parserType);
            parser.Parse();
        }
    }
