        public static class Ext_CollectionExtensions
    {
        public static ObservableCollection<DataRow> ToObservableCollection(this DataTable coll)
        {
            var c = new ObservableCollection<DataRow>();
            foreach (DataRow e in coll.Rows)
                c.Add(e);
            return c;
        }
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> ListOfT)
        {
            ObservableCollection<T> returned = new ObservableCollection<T>();
            foreach (var itm in ListOfT)
            {
                returned.Add(itm);
            }
            return returned;
        }
    }
        public static class Ext_Object
    {
        public static T Coalesce<T>(this T obj, params T[] args)
        {
            if (obj != null || Convert.IsDBNull(obj))
                return obj;
            foreach (T arg in args)
            {
                if (arg != null || Convert.IsDBNull(obj))
                    return arg;
            }
            return default(T);
        }
    }
