    class MyEnumerableClassEnumerator : IEnumerator
    {
        int myStatusVariable = 0;
        public object Current
        {
            get { return myStatusVariable; }
        }
        public bool MoveNext()
        {
            return ++myStatusVariable < 10;
        }
        public void Reset()
        {
            myStatusVariable = 0;
        }
    }
