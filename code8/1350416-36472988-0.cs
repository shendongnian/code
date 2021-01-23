    class Compare : IEqualityComparer<Test>
    {
        public bool Equals(Test x, Test y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Test codeh)
        {
            return codeh.Id.GetHashCode();
        }
    }
