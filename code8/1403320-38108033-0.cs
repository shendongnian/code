    public static class ObjectExtension
    {
        public static List<Foo> MyGenericSortFunction(this List<Foo> list)
        {
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
            return list;
        }
    }
