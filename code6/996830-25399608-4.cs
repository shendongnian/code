     public static class ReflectorHelper
    {
        /// <summary>
        /// Fetches and prepares for initialization without any constructor parameters all types in the current application domain which are assignable to T.
        /// </summary>
        /// <typeparam name="T">The type to which all desired types should be assignable to.</typeparam>
        /// <returns>IEnumerable of initialized objects.</returns>
        public static IEnumerable<T> GetAndActivateAllAssignableTo<T>()
        {
            return GetAndActivateAllAssignableTo<T>(null);
        }
        /// <summary>
        /// Fetches and prepares for initialization with a given constructor parameters all types in the current application domain which are assignable to T.
        /// </summary>
        /// <typeparam name="T">The type to which all desired types should be assignable to.</typeparam>
        /// <param name="consParams">The constructore parametes array - could be null</param>
        /// <returns>IEnumerable of initialized objects.</returns>
        public static IEnumerable<T> GetAndActivateAllAssignableTo<T>(object[] consParams)
        {
            //Deal with null reference for better code consistency
            if (consParams == null)
                consParams = new object[0];
            return from type in AppDomain.CurrentDomain.GetAllAssignableTo<T>()
                   where type.IsInstantiable()
                   select (T)Activator.CreateInstance(type, consParams);
        }
        /// <summary>
        /// Gets the flag which shows whether an object of a given type could be possibly(not guaranteed) instantiated.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>The flag which shows whether an object of a given type could be possibly(not guaranteed) instantiated.</returns>
        public static Boolean IsInstantiable(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type", "The type is null");
            if (type.IsAbstract)
                return false;
            if (type.IsGenericTypeDefinition)
                return false;
            if (type.IsInterface)
                return false;
            return true;
        }
        /// <summary>
        /// Gets all types which are assignable to T type variables.
        /// </summary>
        /// <typeparam name="T">The type to which desired types should be assignable.</typeparam>
        /// <param name="appDomain">The app domain which assemblies should be checked</param>
        /// <returns>The IEnumerable of all types which are assignable to T type variables.</returns>
        public static IEnumerable<Type> GetAllAssignableTo<T>(this AppDomain appDomain)
        {
            if (appDomain == null)
                throw new ArgumentNullException("appDomain", "The app domain is null");
            return GetAllAssignableTo(appDomain, typeof(T));
        }
        /// <summary>
        /// Gets all types which are assignable to T type variables.
        /// </summary>
        /// <param name="appDomain">The app domain which assemblies should be checked</param>
        /// <param name="assignToType">The type to which desired types should be assignable.</param>
        /// <returns>The IEnumerable of all types which are assignable to T type variables.</returns>
        public static IEnumerable<Type> GetAllAssignableTo(this AppDomain appDomain, Type assignToType)
        {
            if (appDomain == null)
                throw new ArgumentNullException("appDomain", "The app domain is null");
            if (assignToType == null)
                throw new ArgumentNullException("assignToType", "The type to check is null");
            return from asm in appDomain.GetAssemblies()
                   from type in asm.GetExportedTypes()
                   where assignToType.IsAssignableFrom(type)
                   select type;
        }
    }
