    public class SQLFunctionMappings : FunctionMappingStore
    {
        public SQLFunctionMappings()
        {
            Add(new FunctionMapping(
                typeof(SQLFunctions),
                "WeekOf",
                1,
                "DATEPART(isowk, {0})")
                // "WEEK({0}, 1)") For MySQL
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
