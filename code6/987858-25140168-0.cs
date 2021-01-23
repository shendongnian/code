    public static class MyExtentionMethods
    {
        public static ObservableCollection<T> TakeSomeIgnoreSome<T>(this ObservableCollection<T> collection, int numberGet, int numberIgnore)
        {
            var col = new ObservableCollection<T>();
            var enumerator = collection.GetEnumerator();
            int counter = 0;
            bool getting = true;
            while(enumerator.MoveNext())
            {
                if (getting)
                    col.Add(enumerator.Current);
                counter++;
                if (getting && counter == numberGet || !getting && counter == numberIgnore)
                {
                    getting ^= true;
                    counter = 0;
                }
                
            }
            return col;
        }
    }
