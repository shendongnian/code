        public static class MyObjectListExtensions
        {
            public static MyObjectList ToList(this IEnumerable<MyObject> collection)
            {
                //You could also call the constructor described above
                var list = new MyObjectList();
                list.AddRange(collection);
                return list;
            }
        }
