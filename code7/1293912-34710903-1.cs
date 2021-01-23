        if (pi.IsGenericType && pi.IsValueType == false && v is List<object>)
            oset = CreateGenericList((List<object>)v, pi.pt, pi.bt, globaltypes);
    As you can see, it checks for the target type being generic, rather than the target type or one of its base types being generic.  
    You could work around this by making your `ComponentTable` be generic:
        public class ComponentTable<TEntityComponent> : List<TEntityComponent> where TEntityComponent : IEntityComponent
        {
            private Dictionary<Type, TEntityComponent> Components { get; set; }
            #region Constructors
            public ComponentTable()
            {
                Components = new Dictionary<Type, TEntityComponent>();
            }
            #endregion
            #region Base Function Overrides
            public void Add(Type _type)
            {
                if (Components.ContainsKey(_type))
                    return;
                InternalAdd(_type, (TEntityComponent)Activator.CreateInstance(_type));
            }
            public new void Add(TEntityComponent _component)
            {
                InternalAdd(_component.GetType(), _component);
            }
            public void Add<T>() where T : IEntityComponent
            {
                Add(typeof(T));
            }
            private void InternalAdd(Type _type, TEntityComponent _component)
            {
                if (Components.ContainsKey(_type))
                    throw new InvalidOperationException("Component already contained");
                Components.Add(_type, _component);
                base.Add(_component);
            }
            public bool Remove(Type _type)
            {
                if (Components.ContainsKey(_type))
                    return InternalRemove(_type, Components[_type]);
                return false;
            }
            public new bool Remove(TEntityComponent _component)
            {
                return InternalRemove(_component.GetType(), _component);
            }
            public bool Remove<T>() where T : IEntityComponent
            {
                return Remove(typeof(T));
            }
            private bool InternalRemove(Type _type, TEntityComponent _component)
            {
                if (!Components.ContainsKey(_type))
                    return false;
                Components.Remove(_type);
                return base.Remove(_component);
            }
            public IEntityComponent Get(Type _type)
            {
                if (Contains(_type))
                    return Components[_type];
                return null;
            }
            public T Get<T>() where T : IEntityComponent
            {
                return (T)Get(typeof(T));
            }
            public bool TryGetValue(Type _type, out TEntityComponent _component)
            {
                return Components.TryGetValue(_type, out _component);
            }
            public bool TryGetValue<T>(out TEntityComponent _component) where T : IEntityComponent
            {
                return TryGetValue(typeof(T), out _component);
            }
            public bool Contains(Type _type)
            {
                return Components.ContainsKey(_type);
            }
            public new bool Contains(TEntityComponent _component)
            {
                return Contains(_component.GetType());
            }
            public bool Contains<T>() where T : IEntityComponent
            {
                return Contains(typeof(T));
            }
            #endregion
        }
    Then change `Blueprint` to be:
        public sealed class Blueprint
        {
            public ComponentTable<IEntityComponent> Components { get; set; }
    And the list contents will be deserialized.  However...
