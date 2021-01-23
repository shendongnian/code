    /// <summary>
    /// This attribute is used to tag classes, enabling them to be constructed by a Factory class. See the <see cref="Factory{Key,Intf}"/> 
    /// class for details.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is okay to mark classes with multiple FactoryClass attributes, even when using different keys or different factories.
    /// </para>
    /// </remarks>
    /// <seealso cref="Factory{Key,Intf}"/>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class FactoryClassAttribute : Attribute
    {
        /// <summary>
        /// This marks a class as eligible for construction by the specified factory type.
        /// </summary>
        /// <example>
        /// [FactoryClass("ScrollBar", typeof(MotifFactory))]
        /// public class MotifScrollBar : IControl { }
        /// </example>
        /// <param name="key">The key used to construct the object</param>
        /// <param name="factoryType">The type of the factory class</param>
        public FactoryClassAttribute(object key, Type factoryType)
        {
            if ((factoryType.IsGenericType &&
                 factoryType.GetGenericTypeDefinition() == typeof(Factory<,>)) ||
                factoryType.IsAbstract || 
                factoryType.IsInterface)
            {
                throw new NotSupportedException("Incorrect factory type: you cannot use GenericFactory or an abstract type as factory.");
            }
            this.Key = key;
            this.FactoryType = factoryType;
        }
        /// <summary>
        /// The key used to construct the object when calling the <see cref="Factory{Key,Intf}.Create(Key)"/> method.
        /// </summary>
        public object Key { get; private set; }
        /// <summary>
        /// The type of the factory class
        /// </summary>
        public Type FactoryType { get; private set; }
    }
    /// <summary>
    /// Provides an interface for creating related or dependent objects.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is an implementation of the Factory pattern. Your factory class should inherit this Factory class and 
    /// you should use the [<see cref="FactoryClassAttribute"/>] attribute on the objects that are created by the factory.
    /// The implementation assumes all created objects share the same constructor signature (which is not checked by the Factory). 
    /// All implementations also share the same <typeparamref name="Intf"/> type and are stored by key. During runtime, you can 
    /// use the Factory class implementation to build objects of the correct type.
    /// </para>
    /// <para>
    /// The Abstract Factory pattern can be implemented by adding a base Factory class with multiple factory classes that inherit from 
    /// the base class and are used for registration. (See below for a complete code example).
    /// </para>
    /// <para>
    /// Implementation of the Strategy pattern can be done by using the Factory pattern and making the <typeparamref name="Intf"/>
    /// implementations algorithms. When using the Strategy pattern, you still need to have some logic that picks when to use which key.
    /// In some cases it can be useful to use the Factory overload with the type conversion to map keys on other keys. When implementing 
    /// the strategy pattern, it is possible to use this overload to determine which algorithm to use.
    /// </para>
    /// </remarks>
    /// <typeparam name="Key">The type of the key to use for looking up the correct object type</typeparam>
    /// <typeparam name="Intf">The base interface that all classes created by the Factory share</typeparam>
    /// <remarks>
    /// The factory class automatically hooks to all loaded assemblies by the current AppDomain. All classes tagged with the FactoryClass
    /// are automatically registered.
    /// </remarks>
    /// <example>
    /// <code lang="c#">
    /// // Create the scrollbar and register it to the factory of the Motif system
    /// [FactoryClass("ScrollBar", typeof(MotifFactory))]
    /// public class MotifScrollBar : IControl { }
    /// 
    /// // [...] add other classes tagged with the FactoryClass attribute here...
    ///
    /// public abstract class WidgetFactory : Factory&lt;string, IControl&gt;
    /// {
    ///     public IControl CreateScrollBar() { return Create("ScrollBar") as IScrollBar; }
    /// }
    ///
    /// public class MotifFactory : WidgetFactory { }
    /// public class PMFactory : WidgetFactory { }
    ///
    /// // [...] use the factory to create a scrollbar
    /// 
    /// WidgetFactory widgetFactory = new MotifFactory();
    /// var scrollbar = widgetFactory.CreateScrollBar(); // this is a MotifScrollbar intance
    /// </code>
    /// </example>
    public abstract class Factory<Key, Intf> : IFactory<Key, Intf>
        where Intf : class
    {
        /// <summary>
        /// Creates a factory by mapping the keys of the create method to the keys in the FactoryClass attributes.
        /// </summary>
        protected Factory() : this((a) => (a)) { }
        /// <summary>
        /// Creates a factory by using a custom mapping function that defines the mapping of keys from the Create 
        /// method, to the keys in the FactoryClass attributes.
        /// </summary>
        /// <param name="typeConversion">A function that maps keys passed to <see cref="Create(Key)"/> to keys used with [<see cref="FactoryClassAttribute"/>]</param>
        protected Factory(Func<Key, object> typeConversion)
        {
            this.typeConversion = typeConversion;
        }
        private Func<Key, object> typeConversion;
        private static object lockObject = new object();
        private static Dictionary<Type, Dictionary<object, Type>> dict = null;
        /// <summary>
        /// Creates an instance a class registered with the <see cref="FactoryClassAttribute"/> attribute by looking up the key.
        /// </summary>
        /// <param name="key">The key used to lookup the attribute. The key is first converted using the typeConversion function passed 
        /// to the constructor if this was defined.</param>
        /// <returns>An instance of the factory class</returns>
        public virtual Intf Create(Key key)
        {
            Dictionary<Type, Dictionary<object, Type>> dict = Init();
            Dictionary<object, Type> factoryDict;
            if (dict.TryGetValue(this.GetType(), out factoryDict))
            {
                Type t;
                return (factoryDict.TryGetValue(typeConversion(key), out t)) ? (Intf)Activator.CreateInstance(t) : null;
            }
            return null;
        }
        /// <summary>
        /// Creates an instance a class registered with the <see cref="FactoryClassAttribute"/> attribute by looking up the key.
        /// </summary>
        /// <param name="key">The key used to lookup the attribute. The key is first converted using the typeConversion function passed 
        /// to the constructor if this was defined.</param>
        /// <param name="constructorParameters">Additional parameters that have to be passed to the constructor</param>
        /// <returns>An instance of the factory class</returns>
        public virtual Intf Create(Key key, params object[] constructorParameters)
        {
            Dictionary<Type, Dictionary<object, Type>> dict = Init();
            Dictionary<object, Type> factoryDict;
            if (dict.TryGetValue(this.GetType(), out factoryDict))
            {
                Type t;
                return (factoryDict.TryGetValue(typeConversion(key), out t)) ? (Intf)Activator.CreateInstance(t, constructorParameters) : null;
            }
            return null;
        }
        /// <summary>
        /// Enumerates all registered attribute keys. No transformation is done here.
        /// </summary>
        /// <returns>All keys currently known to this factory</returns>
        public virtual IEnumerable<Key> EnumerateKeys()
        {
            Dictionary<Type, Dictionary<object, Type>> dict = Init();
            Dictionary<object, Type> factoryDict;
            if (dict.TryGetValue(this.GetType(), out factoryDict))
            {
                foreach (object key in factoryDict.Keys)
                {
                    yield return (Key)key;
                }
            }
        }
        private void TryHook()
        {
            AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(NewAssemblyLoaded);
        }
        private Dictionary<Type, Dictionary<object, Type>> Init()
        {
            Dictionary<Type, Dictionary<object, Type>> d = dict;
            if (d == null)
            {
                lock (lockObject)
                {
                    if (dict == null)
                    {
                        try
                        {
                            TryHook();
                        }
                        catch (Exception) { } // Not available in this security mode. You're probably using shared hosting
                        ScanTypes();
                    }
                    d = dict;
                }
            }
            return d;
        }
        private void ScanTypes()
        {
            Dictionary<Type, Dictionary<object, Type>> classDict = new Dictionary<Type, Dictionary<object, Type>>();
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                AddAssemblyTypes(classDict, ass);
            }
            dict = classDict;
        }
        private void AddAssemblyTypes(Dictionary<Type, Dictionary<object, Type>> classDict, Assembly ass)
        {
            try
            {
                foreach (Type t in ass.GetTypes())
                {
                    if (t.IsClass && !t.IsAbstract &&
                        typeof(Intf).IsAssignableFrom(t))
                    {
                        object[] fca = t.GetCustomAttributes(typeof(FactoryClassAttribute), false);
                        foreach (FactoryClassAttribute f in fca)
                        {
                            if (!(f.Key is Key))
                            {
                                throw new InvalidCastException(string.Format("Cannot cast key of factory object {0} to {1}", t.FullName, typeof(Key).FullName));
                            }
                            Dictionary<object, Type> keyDict;
                            if (!classDict.TryGetValue(f.FactoryType, out keyDict))
                            {
                                keyDict = new Dictionary<object, Type>();
                                classDict.Add(f.FactoryType, keyDict);
                            }
                            keyDict.Add(f.Key, t);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException) { } // An assembly we cannot process. That also means we cannot use it.
        }
        private void NewAssemblyLoaded(object sender, AssemblyLoadEventArgs args)
        {
            lock (lockObject)
            {
                // Make sure new 'create' invokes wait till we're done updating the factory
                Dictionary<Type, Dictionary<object, Type>> classDict = new Dictionary<Type, Dictionary<object, Type>>(dict);
                dict = null;
                Thread.MemoryBarrier();
                AddAssemblyTypes(classDict, args.LoadedAssembly);
                dict = classDict;
            }
        }
    }
