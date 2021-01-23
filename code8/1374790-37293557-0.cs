    public class SortedListRelay : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;
            if (t == null ||
                !t.IsGenericType ||
                t.GetGenericTypeDefinition() != typeof(SortedList<,>))
                return new NoSpecimen();
            
            var dictionaryType = typeof(IDictionary<,>)
                .MakeGenericType(t.GetGenericArguments());
            var dict = context.Resolve(dictionaryType);
            return t
                .GetConstructor(new[] { dictionaryType })
                .Invoke(new[] { dict });
        }
    }
