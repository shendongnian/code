    public class CollectionWrapperFactory<T> : ICollectionWrapperFactory
    {
        private readonly Func<IEnumerable<T>, ICollectionWrapper<T>> _createFunc;
    
        public CollectionWrapperFactory(Func<IEnumerable<T>, ICollectionWrapper<T>> createFunc)
        {
            _createFunc = createFunc;
        }
    
        public ICollectionWrapper<T> CreateCollection(IEnumerable<T> items)
        {
            ICollectionWrapper<T> collectionWrapper;
            if (items == null)
            {
                collectionWrapper = _createFunc(new T[0]);
            }
            else
            {
                collectionWrapper = _createFunc(items);
            }
            return collectionWrapper;
        }
    }
