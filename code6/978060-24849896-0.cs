        /// <summary>
        /// synchronizes an enumerable with a list with two different types, 
        /// </summary>
        /// <typeparam name="TSource">Type of the elements in the source list</typeparam>
        /// <typeparam name="TDestination">Type of the elements in the destination list</typeparam>
        /// <param name="source">Source</param>
        /// <param name="destination">Destination list</param>
        /// <param name="selector">returns the corresponding source object for the destination list item</param>
        /// <param name="creator">Creates new object for the destination list from the source. The selection function applied on the new object must return the source object. </param>
        public static void SyncList<TSource, TDestination>(this IList destination, IEnumerable<TSource> source, Func<TDestination, TSource> selector, Func<TSource, TDestination> creator)
            where TDestination : class
            where TSource : class
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (destination == null)
                throw new ArgumentNullException("destination");
            if (selector == null)
                throw new ArgumentNullException("selector");
            if (creator == null)
                throw new ArgumentNullException("creator");
            var syncObject = destination.IsSynchronized ? destination.SyncRoot : new object();
            lock (syncObject)
            {
                var ExistingItems = destination.OfType<TDestination>().Where(d => selector(d) != null).ToDictionary(d => selector(d));
                foreach (var s in source)
                {
                    if (!ExistingItems.Remove(s)) // s does not exist yet in the destination list
                    {
                        var NewObject = creator(s);
                        if (selector(NewObject) != s)
                            throw new ArgumentException("the selector must return the creation object of the new item");
                        destination.Add(creator(s));
                    }
                }
                var RemovedItems = ExistingItems.Values;
                if (RemovedItems.Count == destination.Count)
                    destination.Clear();
                else
                    foreach (var i in RemovedItems)
                    {
                        destination.Remove(i);
                    }
            }
        }
