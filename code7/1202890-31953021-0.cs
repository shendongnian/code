        public static Comparer<T> Default {
            get {
                Contract.Ensures(Contract.Result<Comparer<T>>() != null);
 
                Comparer<T> comparer = defaultComparer;
                if (comparer == null) {
                    comparer = CreateComparer();
                    defaultComparer = comparer;
                }
                return comparer;
            }
        }
        private static Comparer<T> CreateComparer() {
            RuntimeType t = (RuntimeType)typeof(T);
 
            // If T implements IComparable<T> return a GenericComparer<T>
    #if FEATURE_LEGACYNETCF
            //(SNITP)
    #endif
                if (typeof(IComparable<T>).IsAssignableFrom(t)) {
                    return (Comparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(GenericComparer<int>), t);
                }
 
            // If T is a Nullable<U> where U implements IComparable<U> return a NullableComparer<U>
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                RuntimeType u = (RuntimeType)t.GetGenericArguments()[0];
                if (typeof(IComparable<>).MakeGenericType(u).IsAssignableFrom(u)) {
                    return (Comparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(NullableComparer<int>), u);
                }
            }
            // Otherwise return an ObjectComparer<T>
          return new ObjectComparer<T>();
        }
