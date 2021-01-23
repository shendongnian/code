    class MyClass : IEnumerable<SomeObject>
    {
        private bool IsNextAvailablle()
        {
            // implementation
        }
        private SomeObject GetNext()
        {
            return nextObject;
        }
        public IEnumerator<SomeObject> GetEnumerator()
        {
            while (IsNextAvailablle())
            {
                yield return GetNext();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
