        #region Private methods
        static IEnumerable<TrackInfo> ProcessItems<T>(IEnumerable<T> items, Func<DataContext, IEnumerable<T>, IEnumerable<TrackInfo>> func)
        {
            using (var dataContext = new DataContext())
            {
                foreach (var item in func(dataContext, items))
                {
                    yield return item;
                }
                dataContext.SubmitChanges();
            }
        }
        static IEnumerable<TrackInfo> ProcessItems<T>(DataContext dataContext, IEnumerable<T> items, Func<DataContext, T, TrackInfo> func)
        {
            return items.Select(t => func(dataContext, t));
        }
        TrackInfo ProcessItem<T>(DataContext dataContext, T item, Action<TrackInfo> action)
        {
            if (typeof(T) == typeof(string))
            {
                return ProcessItem(dataContext, this[item as string], action);
            }
            if (typeof(T) == typeof(TrackInfo))
            {
                var track = item as TrackInfo;
                action(track);
                return track;
            }
            throw new ArgumentException("The type must be string or TrackInfo");
        }
        #endregion
        #region Public methods
        public IEnumerable<TrackInfo> Add<T>(IEnumerable<T> items)
        {
            return ProcessItems(items, Add);
        }
        public IEnumerable<TrackInfo> Add<T>(DataContext dataContext, IEnumerable<T> items)
        {
            return ProcessItems(dataContext, items, Add);
        }
        public TrackInfo Add<T>(DataContext dataContext, T item)
        {
            return ProcessItem(dataContext, item, 
                i =>
                {
                    dataContext.TrackInfos.InsertOnSubmit(i);
                    Add(i);
                });
        }
    
        public IEnumerable<TrackInfo> Delete<T>(IEnumerable<T> items)
        {
            return ProcessItems(items, Delete);
        }
        public IEnumerable<TrackInfo> Delete<T>(DataContext dataContext, IEnumerable<T> items)
        {
            return ProcessItems(dataContext, items, Delete);
        }
        public TrackInfo Delete<T>(DataContext dataContext, T item)
        {
            return ProcessItem(dataContext, item,
                i =>
                {
                    dataContext.TrackInfos.Attach(i);
                    dataContext.TrackInfos.DeleteOnSubmit(i);
                    Remove(i);
                });
        }
