    static public class Extension
    {
        static public IEnumerable CastDynamic(this	IEnumerable Source, Type Type)
        {
            return
                (IEnumerable)
                typeof(Enumerable)
                .GetMethod("Cast", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                .MakeGenericMethod(Type)
                .Invoke(null, new[] { Source });
        }
        static public IEnumerable CastToFirstType(this	IEnumerable Source)
        {
            if (0 == Source.Take(1).Count())
            {
                return Source;
            }
            return CastDynamic(Source, Source.Cast<object>().FirstOrDefault().GetType());
        }
        static public IEnumerable WhereCastToFirstType(this	IEnumerable Source, string Predicate, params object[] values)
        {
            return Source.CastToFirstType().Where(Predicate, values);
        }
    }
