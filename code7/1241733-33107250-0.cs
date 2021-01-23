    class Foo
    {
        public IEnumerable<int> A
        {
            get
            {
                foreach (int i in A)
                    yield return i;
            }
        }
        private int[] a;
        public void DoSomething()
        {
            int[] arr = A.ToArray();
        }
    }
