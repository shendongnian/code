    public class CustomList<T> : List<T>
    {
        public static CustomList<T> operator +(CustomList<T> list, T element)
        {
            list.Add(element);
            return list;
        }
    }
