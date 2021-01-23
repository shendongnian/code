    namespace Extensions
        {
            public static class LinqExtensions
            {
                public static String ReturnSeparatedString<T>(this DataTable datatable, string field, string separator)
                {
                    var unique =
                        datatable.AsEnumerable()
                            .Select(s => new {cc = s.Field<string>(field),}).Distinct();
        
                    return String.Join(separator, unique.Select(o => o.cc));
                }
        }
    }
