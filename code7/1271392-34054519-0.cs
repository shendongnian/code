    public partial class MocksProvider : ImplementationProvider
    {
        public override Maybe<T> get<T>()
        { 
            Type type = typeof(T);
            if (!type.IsGenericType)
                return new Mock<T>().Object;
            List<Type> generic_args = type.GetGenericArguments().ToList();
            Type generic = type.GetGenericTypeDefinition();
            Type return_type = generic_args.Last();
            Type mock_type_definition = typeof(Mock<>);
            var concrete_mock_definition = mock_type_definition.MakeGenericType(return_type);
    
            Type[] types_to_check = new[] { typeof(Func<>), typeof(Func<,>), typeof(Func<,,>), typeof(Func<,,,>) };
            for (int i = 0; i < types_to_check.Length; ++i)
            {
                if (generic == types_to_check[i])
                {
                    var mirrors_args = new[] { object_extractor.MakeGenericMethod(new[] { return_type}).Invoke(null,
                         new[] { Activator.CreateInstance(concrete_mock_definition)}) };
                    return (T)mirrors[i].MakeGenericMethod(generic_args.ToArray())
                        .Invoke(null, mirrors_args);
                }
            }
            return new Mock<T>().Object;
        }
        static T extract_object_from_mock<T>(Mock<T> mock) where T :class
        {
            return mock.Object;
        }
        static Func<T> make_func<T>(T result)
        {
            return () => result;
        }
        static Func<T1, T2> make_func<T1, T2>(T2 result)
        {
            return (p1) => result;
        }
        static Func<T1, T2, T3> make_func<T1, T2, T3>(T3 result)
        {
            return (p1, p2) => result;
        }
        static Func<T1, T2, T3, T4> make_func<T1, T2, T3, T4>(T4 result)
        {
            return (p1, p2,p3) => result;
        }
        static MethodInfo[] mirrors;
        static MethodInfo object_extractor;
        static MocksProvider()
        {
            mirrors = typeof(MocksProvider)
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(x => x.Name == "make_func")
                .Select(x => new { M = x, L = x.GetGenericArguments().Count() })
                .OrderBy(e => e.L)
                .Select(e => e.M)
                .ToArray();
            object_extractor = typeof(MocksProvider)
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(x => x.Name == "extract_object_from_mock")
                .First();
        }
    }
