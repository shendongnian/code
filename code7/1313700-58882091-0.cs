        public class MyClass
            {
                private readonly ICollectionWrapper<TModel> _collectionWrapper;
                    public MyClass(ICollectionWrapper<TModel> collectionWrapper)
                    {
                                _collectionWrapper= collectionWrapper;
                    }
            }
