    What it appears you are doing is re-inventing [`KeyedByTypeCollection<TItem>`](https://msdn.microsoft.com/en-us/library/ms404549%28v=vs.110%29.aspx).  Rather than do that, you can just use it.  Using this class, your `ComponentTable` becomes very simple:
        public class ComponentTable<TEntityComponent> : KeyedByTypeCollection<TEntityComponent> where TEntityComponent : IEntityComponent
        {
            public void Add(Type _type)
            {
                if (Contains(_type))
                    return;
                Add((TEntityComponent)Activator.CreateInstance(_type));
            }
            public void Add<T>() where T : IEntityComponent, new()
            {
                Add(typeof(T));
            }
        }
    Now the collection can be serialized and deserialized with no data corruption on Microsoft .Net.  However...
