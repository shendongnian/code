    public List<T> Intersetc<T>(List<T> list1, List<T> list2) where T : IComparable<T>
    {
        return list1.Intersect(list2, new MyEqualityComparer<T>()).ToList();
    }
    public class MyEqualityComparer<T> : IEqualityComparer<T> where T : IComparable<T>
    {
        public bool Equals(T t1, T t2)
        {
            return t1?.GetHashCode() == t2?.GetHashCode() || t1.CompareTo(t2) == 0;
        }
        public int GetHashCode(T t)
        {
            return t.GetHashCode();
        }
    }
