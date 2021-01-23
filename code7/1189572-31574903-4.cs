    namespace V2
    {
        // https://stackoverflow.com/questions/31552724/how-why-does-xmlserializer-treat-a-class-differently-when-it-implements-ilistt
        public class Vector2 : V1.Vector2, IList<double>
        {
            public Vector2() : base() { }
            public Vector2(double x, double y) : base(x, y) { }
            #region IList<double> Members
            public int IndexOf(double item)
            {
                for (var i = 0; i < Count; i++)
                    if (this[i] == item)
                        return i;
                return -1;
            }
            public void Insert(int index, double item)
            {
                throw new NotImplementedException();
            }
            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }
            #endregion
            #region ICollection<double> Members
            public void Add(double item)
            {
                throw new NotImplementedException();
            }
            public void Clear()
            {
                throw new NotImplementedException();
            }
            public bool Contains(double item)
            {
                return IndexOf(item) >= 0;
            }
            public void CopyTo(double[] array, int arrayIndex)
            {
                foreach (var item in this)
                    array[arrayIndex++] = item;
            }
            public int Count
            {
                get { return 2; }
            }
            public bool IsReadOnly
            {
                get { return true; }
            }
            public bool Remove(double item)
            {
                throw new NotImplementedException();
            }
            #endregion
            #region IEnumerable<double> Members
            public IEnumerator<double> GetEnumerator()
            {
                yield return X;
                yield return Y;
            }
            #endregion
            #region IEnumerable Members
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
    }
