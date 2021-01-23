    public class TestEnumComparer : IEqualityComparer<TestEnum>
    {
        public bool Equals(TestEnum x, TestEnum y)
        {
            return x == y;
        }
        public int GetHashCode(TestEnum obj)
        {
            return obj.GetHashCode();
        }
    }
