    class MyObjectList<T>: IEnumerable<T> {
    public IEnumerator<T> GetEnumerator() {
        T[] a = items; int n = size;
        for(int i = 0; i < n; i++)
            yield return a[i]; }
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator(); }
