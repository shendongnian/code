    public class SnapshotableListEnumerator<T> : IEnumerator<T>
    {
      private readonly IList<T> _list;
      private int _idx;
      private SnapshotableListEnumerator(IList<T> list, int idx)
      {
        _list = list;
        _idx = idx;
      }
      public SnapshotableListEnumerator(IList<T> list)
        : this(list, -1)
      {
      }
      public bool MoveNext()
      {
        // Note that this enumerator doesn't complain about the list
        // changing during enumeration, but we do want to check that
        // a change doesn't push us past the end of the list, rather
        // than caching the size.
        if(_idx >= _list.Count)
          return false;
        ++_idx;
        return true;
      }
      public void Reset()
      {
        _idx = -1;
      }
      public T Current
      {
        get
        {
          if(_idx < 0 || _idx >= _list.Count)
            throw new InvalidOperationException();
          return _list[_idx];
        }
      }
      object IEnumerator.Current
      {
        get { return Current; }
      }
      public void Dispose()
      {
      }
      public SnapshotableListEnumerator<T> Snapshot()
      {
        return new SnapshotableListEnumerator<T>(_list, _idx);
      }
    }
    public static class SnapshotableListEnumeratorHelper
    {
      public static SnapshotableListEnumerator<T> GetSnapshotableEnumerator<T>(this IList<T> list)
      {
        return new SnapshotableListEnumerator<T>(list);
      }
    }
