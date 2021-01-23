    public class RandomEnumSequenceGenerator<T> : ISpecimenBuilder where T : struct
    {
        private static Random _random = new Random();
        private T[] _values;
    
        public RandomEnumSequenceGenerator()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }
    
            _values = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToArray();
        }
    
        public object Create(object request, ISpecimenContext context)
        {
            var index = _random.Next(_values.Length);
            return _values[index];
        }
    }
