        public static TReturnType As<TReturnType,TIdentifier>(this BaseClass<TIdentifier> proxyObject)
            where TReturnType : class
        {
            return proxyObject.Me as TReturnType;
        }
