    public class MyClass : Foo
    {
        public int SomethingNonObsolete
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        [Obsolete]
        public IEnumerator<Bar> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        [Obsolete]
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
