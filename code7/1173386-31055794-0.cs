    public class GenericClass<T1>
    {
        public class InnerClass<T2>
        {
            public static Tuple<T1, T2, T3> A<T3>()
            {
                return null;
            }
        }
    }
    Type type = typeof(GenericClass<int>.InnerClass<long>);
    var methodInfo = type.GetMethod("A");
    MethodInfo method = (MethodInfo)type.Module.ResolveMethod(methodInfo.MetadataToken);
