    using System;
    using System.Collections;
    class MyEnumerableClass : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerableClassEnumerator();
        }
    }
