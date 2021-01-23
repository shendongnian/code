    public partial class MocksProvider : ImplementationProvider
    {
        static MethodInfo[] method_mocks = typeof(MocksProvider)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Where(m => m.Name == "func_mock" || m.Name == "action_mock")
            .ToArray();
        static Dictionary<Type, Object> cache = new Dictionary<Type, object>();
        public override Maybe<T> get<T>()
        {
            if (cache.ContainsKey(typeof(T)))
            {
                return (T)cache[typeof(T)];
            }
            T res=null;
            try_mock_as_method(ref res);
            if(res==null)
            {
                res = new Mock<T>().Object;
            }
            
            cache.Add(typeof(T),res);
            return res;
        }
        static void try_mock_as_method<T>(ref T target)
        {
            Type type = typeof(T);
            if (type == typeof(Action))
            {
                Action action = () => { };
                target = (T)(Object)action;
                return;
            }
            if (!type.IsGenericType)
            {
                return;
            }
            Type[] generic_args = type.GetGenericArguments();
            Type type_definition = type.GetGenericTypeDefinition();
            foreach (MethodInfo mock_generator in method_mocks)
            {
                Type generator_return_type = mock_generator.ReturnType.GetGenericTypeDefinition();
                if (type_definition == generator_return_type)
                {
                    target = (T)mock_generator.MakeGenericMethod(generic_args).Invoke(null, new object[] { });
                    return;
                }
            }
        }
        static Func<T> func_mock<T>() where T : class
        {
            return () => new Mock<T>().Object;
        }
        static Func<P1, T> func_mock<P1, T>() where T : class
        {
            return (p1) => new Mock<T>(p1).Object;
        }
        static Func<P1, P2, T> func_mock<P1, P2, T>() where T : class
        {
            return (p1, p2) => new Mock<T>(p1, p2).Object;
        }
        static Func<P1, P2, P3, T> func_mock<P1, P2, P3, T>() where T : class
        {
            return (p1, p2, p3) => new Mock<T>(p1, p2, p3).Object;
        }
        static Func<P1, P2, P3, P4, T> func_mock<P1, P2, P3, P4, T>() where T : class
        {
            return (p1, p2, p3, p4) => new Mock<T>(p1, p2, p3, p4).Object;
        }
        static Action<P1> action_mock<P1>()
        {
            return (p1) => { };
        }
        static Action<P1, P2> action_mock<P1, P2>()
        {
            return (p1, p2) => { };
        }
        static Action<P1, P2, P3> action_mock<P1, P2, P3>()
        {
            return (p1, p2, p3) => { };
        }
        static Action<P1, P2, P3, P4> action_mock<P1, P2, P3, P4>()
        {
            return (p1, p2, p3, p4) => { };
        }
    }
