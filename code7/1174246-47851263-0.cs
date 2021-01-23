    public static class MoqExtentions
    {
        public static void SetupReturn<T>(this Mock<ObjectResult<T>> mock, T whatToReturn)
        {
            IEnumerator<T> enumerator = ((IEnumerable<T>) new T[] {whatToReturn}).GetEnumerator();
            mock.Setup(or => or.GetEnumerator())
                .Returns(() => enumerator);
        }
    }
