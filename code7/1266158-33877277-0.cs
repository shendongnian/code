    class CollectionA { }
    class CollectionB { }
    class Synchronise<T, S>
    {
        public static Synchronise<CollectionB, CollectionA> Create()
        {
            return new Synchronise<CollectionB, CollectionA>(MappingStoT, MappingTtoS);
        }
        public Synchronise(Func<IEnumerable<T>, IEnumerable<S>> MappingStoT, Func<IEnumerable<S>, IEnumerable<T>> MappingTtoS)
        {
        }
        public static IEnumerable<CollectionA> MappingStoT(IEnumerable<CollectionB> CollectionForEdit)
        {
            return null;
        }
        public static IEnumerable<CollectionB> MappingTtoS(IEnumerable<CollectionA> CollectionForEdit)
        {
            return null;
        }
    }
