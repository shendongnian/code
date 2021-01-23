    /// <summary>
    /// Abstract base type for a generic collection wrapper where, to differentiate 
    /// between arrays and lists and other types of collections of the same underlying
    /// item type, it is necessary to introduce an intermediary type to establish 
    /// distinct xsi:type values.
    /// </summary>
    public abstract class CollectionWrapper
    {
        [XmlIgnore]
        public abstract IEnumerable RealCollection { get; }
        static bool TryCreateWrapperType<TElement>(Type actualType, out Type wrapperType)
        {
            if (actualType.IsArray 
                || actualType.IsPrimitive 
                || actualType == typeof(string) 
                || !typeof(IEnumerable).IsAssignableFrom(actualType)
                || actualType == typeof(TElement) // Not polymorphic
                || !actualType.IsGenericType)
            {
                wrapperType = null;
                return false;
            }
            var args = actualType.GetGenericArguments();
            if (args.Length != 1)
            {
                wrapperType = null;
                return false;
            }
            if (actualType.GetGenericTypeDefinition() == typeof(List<>))
            {
                wrapperType = typeof(ListWrapper<>).MakeGenericType(args);
            }
            else if (actualType.GetGenericTypeDefinition() == typeof(HashSet<>))
            {
                wrapperType = typeof(HashSetWrapper<>).MakeGenericType(args);
            }
            else if (actualType.GetGenericTypeDefinition() == typeof(SortedSet<>))
            {
                wrapperType = typeof(SortedSetWrapper<>).MakeGenericType(args);
            }
            else 
            {
                var collectionTypes = actualType.GetCollectionItemTypes().ToList();
                if (collectionTypes.SequenceEqual(args))
                    wrapperType = typeof(CollectionWrapper<,>).MakeGenericType(new [] { actualType, args[0] });
                else
                {
                    wrapperType = null;
                    return false;
                }
            }
            if (!typeof(TElement).IsAssignableFrom(wrapperType))
            {
                wrapperType = null;
                return false;
            }
            return true;
        }
        public static TElement Wrap<TElement>(TElement item)
        {
            if (item == null)
                return item;
            var type = item.GetType();
            if (type == typeof(TElement))
                return item;
            Type wrapperType;
            if (!TryCreateWrapperType<TElement>(type, out wrapperType))
                return item;
            return (TElement)Activator.CreateInstance(wrapperType, item);
        }
        public static TElement Unwrap<TElement>(TElement item)
        {
            if (item is CollectionWrapper)
                return (TElement)((CollectionWrapper)(object)item).RealCollection;
            return item;
        }
    }
    /// <summary>
    /// Generic wrapper type for a generic collection of items.
    /// </summary>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TElement"></typeparam>
    public class CollectionWrapper<TCollection, TElement> : CollectionWrapper where TCollection : ICollection<TElement>, new()
    {
        public class CollectionWrapperEnumerable : IEnumerable<TElement>
        {
            readonly TCollection collection;
            public CollectionWrapperEnumerable(TCollection collection)
            {
                this.collection = collection;
            }
            public void Add(TElement item)
            {
                collection.Add(CollectionWrapper.Unwrap<TElement>(item));
            }
            #region IEnumerable<TElement> Members
            public IEnumerator<TElement> GetEnumerator()
            {
                foreach (var item in collection)
                    yield return CollectionWrapper.Wrap(item);
            }
            #endregion
            #region IEnumerable Members
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
        readonly TCollection collection;
        readonly CollectionWrapperEnumerable enumerable;
        public CollectionWrapper()
            : this(new TCollection())
        {
        }
        public CollectionWrapper(TCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            this.collection = collection;
            this.enumerable = new CollectionWrapperEnumerable(collection);
        }
        [XmlElement("Item")]
        public CollectionWrapperEnumerable SerializableEnumerable { get { return enumerable; } }
        [XmlIgnore]
        public override IEnumerable RealCollection { get { return collection; } }
    }
    // These three subclasses of CollectionWrapper for commonly encounterd collections were introduced to improve readability
    public class ListWrapper<TElement> : CollectionWrapper<List<TElement>, TElement>
    {
        public ListWrapper() : base() { }
        public ListWrapper(List<TElement> list) : base(list) { }
    }
    public class HashSetWrapper<TElement> : CollectionWrapper<HashSet<TElement>, TElement>
    {
        public HashSetWrapper() : base() { }
        public HashSetWrapper(HashSet<TElement> list) : base(list) { }
    }
    public class SortedSetWrapper<TElement> : CollectionWrapper<SortedSet<TElement>, TElement>
    {
        public SortedSetWrapper() : base() { }
        public SortedSetWrapper(SortedSet<TElement> list) : base(list) { }
    }
    public static class TypeExtensions
    {
        /// <summary>
        /// Return all interfaces implemented by the incoming type as well as the type itself if it is an interface.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfacesAndSelf(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException();
            if (type.IsInterface)
                return new[] { type }.Concat(type.GetInterfaces());
            else
                return type.GetInterfaces();
        }
        public static IEnumerable<Type> GetCollectionItemTypes(this Type type)
        {
            foreach (Type intType in type.GetInterfacesAndSelf())
            {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    yield return intType.GetGenericArguments()[0];
                }
            }
        }
    }
