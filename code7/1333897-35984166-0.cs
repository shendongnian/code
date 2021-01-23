    public static class SessionHelper
    {
        public static void Save2<T>(this Session session, T obj)
        {
            SessionHelperImpl<T>.Save(session, obj);
        }
        private static class SessionHelperImpl<T>
        {
            public static readonly Action<Session, T> Save;
            static SessionHelperImpl() 
            {
                MethodInfo saveT = (from x in typeof(Session).GetMethods()
                                    where x.Name == "Save" && x.IsGenericMethod
                                    let genericArguments = x.GetGenericArguments()
                                    where genericArguments.Length == 1
                                    let parameters = x.GetParameters()
                                    where parameters.Length == 1 && parameters[0].ParameterType == genericArguments[0]
                                    select x).Single();
                MethodInfo save = saveT.MakeGenericMethod(typeof(T));
                Save = (Action<Session, T>)save.CreateDelegate(typeof(Action<Session, T>));
            }
        }
    }
