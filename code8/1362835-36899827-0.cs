    public class RandomEnumSequenceGenerator<T> : ISpecimenBuilder where T : struct
    {
        private static Random _random = new Random();
        private Array _values;
    
        public RandomEnumSequenceGenerator()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }
            _values = Enum.GetValues(typeof(T));
        }
    
        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;
            if (t == null || t != typeof(T))
                return new NoSpecimen();
    
            var index = _random.Next(0, _values.Length - 1);
            return _values.GetValue(index);
        }
    }
