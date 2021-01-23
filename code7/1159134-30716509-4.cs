    public static class LazyFields
    {
        private static readonly ConcurrentDictionary<Type, IBuildUp> _registry = new ConcurrentDictionary<Type,IBuildUp>();
        public interface IConfigureType<T> where T : class
        {
            IConfigureType<T> SetProvider<FT>(string fieldName, Func<T, FT> provider);
            IConfigureType<T> SetProvider<F, FT>(Expression<Func<T, F>> fieldExpression, Func<T, FT> provider) where F : LazyField<FT>;
        }
        public static void BuildUp(object instance)
        {
            System.Diagnostics.Debug.Assert(instance != null);
            var builder = _registry.GetOrAdd(instance.GetType(), BuildInitializer);
            builder.BuildUp(instance);
        }
        public static IConfigureType<T> Configure<T>() where T : class
        {
            return (IConfigureType<T>)_registry.GetOrAdd(typeof(T), BuildInitializer);
        }
        private interface IBuildUp 
        {
            void BuildUp(object instance);
        }
        private class TypeCfg<T> : IBuildUp, IConfigureType<T> where T : class
        {
            private readonly List<FieldInfo> _fields;
            private readonly Dictionary<string, Action<T>> _initializers;
            public TypeCfg()
            {
                _fields = typeof(T)
                    .GetFields(BindingFlags.Instance | BindingFlags.Public)
                    .Where(IsLazyField)
                    .ToList();
                _initializers = _fields.ToDictionary(x => x.Name, BuildDefaultSetter);
            }
            public IConfigureType<T> SetProvider<FT>(string fieldName, Func<T,FT> provider) 
            {
                var pi = _fields.First(x => x.Name == fieldName);
                _initializers[fieldName] = BuildSetter<FT>(pi, provider);
                return this;
            }
            public IConfigureType<T> SetProvider<F,FT>(Expression<Func<T,F>> fieldExpression, Func<T,FT> provider) 
                where F : LazyField<FT>
            {
                return SetProvider((fieldExpression.Body as MemberExpression).Member.Name, provider);
            }
            public void BuildUp(object instance)
            {
                var typedInstance = (T)instance;
                foreach (var initializer in _initializers.Values)
                    initializer(typedInstance);
            }
            private bool IsLazyField(FieldInfo fi)
            {
                return fi.FieldType.IsGenericType && fi.FieldType.GetGenericTypeDefinition() == typeof(LazyField<>);
            }
            private Action<T> BuildDefaultSetter(FieldInfo fi)
            {
                var itemType = fi.FieldType.GetGenericArguments()[0];
                var defValue = Activator.CreateInstance(typeof(LazyField<>).MakeGenericType(itemType));
                return (inst) => fi.SetValue(inst, defValue);
            }
            private Action<T> BuildSetter<FT>(FieldInfo fi, Func<T, FT> provider)
            {
                return (inst) => fi.SetValue(inst, new LazyField<FT>(new Lazy<FT>(() => provider(inst))));
            }
        }
        private static IBuildUp BuildInitializer(Type targetType)
        {
            return (IBuildUp)Activator.CreateInstance(typeof(TypeCfg<>).MakeGenericType(targetType));
        }
    }
