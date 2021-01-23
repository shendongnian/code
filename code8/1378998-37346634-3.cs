    class MyClass : IEnumerable<SomeObject>
    {
        public IEnumerator<SomeObject> GetEnumerator()
        {
            while (... is next available ...)
                yield return ... get next ...;
        }
        public IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    } 
