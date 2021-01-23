    public class SQLFunctionMappings : FunctionMappingStore
    {
        public SQLFunctionMappings()
            : base()
        {
            this.Add(new FunctionMapping
                (
                typeof(SQLFunctions),
                "WeekOf",
                1,
                "DATEPART(isowk, {0})")
                );
        }
    }
    public class SQLFunctions
    {
        public static int? WeekOf(DateTime? date)
        {
            return null;
        }
    }
