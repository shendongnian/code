    public class ConvertibleList<Derived,Parent> : IList<Derived> {
      private IList<Parent> m_List;
      private Func<Parent, Derived> m_ParentToDerived;
      private Func<Derived, Parent> m_DerivedToParent;
      private class Enumerator : IEnumerator<Derived> {
        private IEnumerator<Parent> m_Enumerator;
        private Func<Parent, Derived> m_ParentToDerived;
        public Enumerator(IEnumerator<Parent> enumerator, Func<Parent, Derived> parentToDerived) {
          m_Enumerator = enumerator;
          m_ParentToDerived = parentToDerived;
        }
        public Derived Current {
          get { return m_ParentToDerived(m_Enumerator.Current); }
        }
        object IEnumerator.Current {
          get { return m_ParentToDerived(m_Enumerator.Current); }
        }
        public bool MoveNext() {
          return m_Enumerator.MoveNext();
        }
        public void Reset() {
          m_Enumerator.Reset();
        }
        public void Dispose() {
          m_Enumerator.Dispose();
        }
      }
      private class Enumerable : IEnumerable<Derived> {
        private IEnumerable<Parent> m_Parent;
        private Func<Parent, Derived> m_ParentToDerived;
        public Enumerable(IEnumerable<Parent> parent, Func<Parent, Derived> parentToDerived) {
          m_Parent = parent;
          m_ParentToDerived = parentToDerived;
        }
        public IEnumerator<Derived> GetEnumerator() {
          return new Enumerator(m_Parent.GetEnumerator(), m_ParentToDerived);
        }
        IEnumerator IEnumerable.GetEnumerator() {
          return new Enumerator(m_Parent.GetEnumerator(), m_ParentToDerived);
        }
      }
      public ConvertibleList(IList<Parent> list, Func<Parent, Derived> parentToDerived, Func<Derived, Parent> derivedToParent) {
        if (list == null) {
          throw new ArgumentNullException("list");
        }
        m_List = list;
        m_ParentToDerived = parentToDerived;
        m_DerivedToParent = derivedToParent;
      }
      public int IndexOf(Derived item) {
        return m_List.IndexOf(m_DerivedToParent(item));
      }
      public void Insert(int index, Derived item) {
        m_List.Insert(index, m_DerivedToParent(item));
      }
      public void RemoveAt(int index) {
        m_List.RemoveAt(index);
      }
      public Derived this[int index] {
        get { return m_ParentToDerived(m_List[index]); }
        set { m_List[index] = m_DerivedToParent(value); }
      }
      public void Add(Derived item) {
        m_List.Add(m_DerivedToParent(item));
      }
      public void Clear() {
        m_List.Clear();
      }
      public bool Contains(Derived item) {
        return m_List.Contains(m_DerivedToParent(item));
      }
      public void CopyTo(Derived[] array, int arrayIndex) {
        var parentArray = new Parent[array.Length];
        for (var i = 0; i < array.Length; i++) {
          parentArray[i] = m_DerivedToParent(array[i]);
        }
        m_List.CopyTo(parentArray, arrayIndex);
      }
      public int Count {
        get { return m_List.Count; }
      }
      public bool IsReadOnly {
        get { return m_List.IsReadOnly; }
      }
      public bool Remove(Derived item) {
        return m_List.Remove(m_DerivedToParent(item));
      }
      public IEnumerator<Derived> GetEnumerator() {
        return new Enumerator(m_List.GetEnumerator(), m_ParentToDerived);
      }
      IEnumerator IEnumerable.GetEnumerator() {
        return new Enumerator(m_List.GetEnumerator(), m_ParentToDerived);
      }
    }
