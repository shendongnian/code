    public class RepeatAttribute : DataAttribute
    {
        private readonly int _count;
        public RepeatAttribute(int count)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException(
                    "count",
                    "Repeat count must be greater than 0.");
            _count = count;
        }
        public override IEnumerable<object[]> GetData(
            MethodInfo methodUnderTest,
            Type[] parameterTypes)
        {
            return Enumerable.Repeat(new object[0], _count);
        }
    }
