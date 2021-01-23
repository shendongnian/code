     class GenericClass<T> : IEnumerable<T>
    {
        T[] elements;
        public GenericClass(T[] elements)
        {
            this.elements = elements;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < cars.Length; index++)
                yield return elements[index];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
