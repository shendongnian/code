    public class ComponentEventAggregator
    {
        public void AddComponent(object component)
        {
            var typeGroup = this.GetTypeGroup(component.GetType());
            typeGroup.AddComponent(component);
        }
        public void Update()
        {
            foreach (var typeGroup in this.typeGroupsByType.Values)
            {
                typeGroup.Update();
            }
        }
        public void RemoveComponent(object component)
        {
            TypeGroup typeGroup;
            if (this.typeGroupsByType.TryGetValue(component.GetType(), out typeGroup))
            {
                typeGroup.RemoveComponent(component);
            }
        }
        private TypeGroup GetTypeGroup(Type type)
        {
            TypeGroup typeGroup;
            if (!this.typeGroupsByType.TryGetValue(type, out typeGroup))
            {
                typeGroup = TypeGroup.Create(type);
                this.typeGroupsByType[type] = typeGroup;
            }
            return typeGroup;
        }
        private abstract class TypeGroup
        {
            public abstract void Update();
            // ... LateUpdate, OnApplicationPause, etc.
            public abstract void AddComponent(object component);
            public abstract void RemoveComponent(object component);
            // Create a TypeGroup<T> for the specified type
            public static TypeGroup Create(Type type)
            {
                var closedDelegatesType = typeof(TypeGroup<>).MakeGenericType(new[] { type });
                var typeDelegates = closedDelegatesType.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
                return (TypeGroup)typeDelegates;
            }
        }
        private class TypeGroup<T> : TypeGroup where T : class
        {
            public TypeGroup()
            {
                this.update = CreateOpenDelegate("Update");
                this.lateUpdate = CreateOpenDelegate("LateUpdate");
                this.onApplicationPause = CreateOpenDelegate<bool>("OnApplicationPause");
                // ...other Unity events
            }
            public override void Update()
            {
                if (this.update != null)
                {
                    foreach (var component in this.components)
                    {
                        this.update(component);
                    }
                }
            }
            public override void AddComponent(object component)
            {
                var t = component as T;
                if (t != null)
                {
                    this.components.Add(t);
                }
            }
            public override void RemoveComponent(object component)
            {
                var t = component as T;
                if (t != null)
                {
                    this.components.Remove(t);
                }
            }
            private static Action<T> CreateOpenDelegate(string functionName)
            {
                var method = GetMethod(functionName, Type.EmptyTypes);
                if (method == null)
                {
                    return null;
                }
                return (Action<T>)Delegate.CreateDelegate(typeof(Action<T>), method);
            }
            private static Action<T, TArg1> CreateOpenDelegate<TArg1>(string functionName)
            {
                var method = GetMethod(functionName, new[] { typeof(TArg1) });
                if (method == null)
                {
                    return null;
                }
                return (Action<T, TArg1>)Delegate.CreateDelegate(typeof(Action<T, TArg1>), method);
            }
            private static MethodInfo GetMethod(string functionName, Type[] parameterTypes)
            {
                return typeT.GetMethod(functionName, BindingFlags.Instance | BindingFlags.Public, null, parameterTypes, null);
            }
            private readonly Action<T> update;
            private readonly Action<T> lateUpdate;
            private readonly Action<T, bool> onApplicationPause;
            private List<T> components = new List<T>();
            private static readonly Type typeT = typeof(T);
        }
        private Dictionary<Type, TypeGroup> typeGroupsByType = new Dictionary<Type, TypeGroup>();
    }
