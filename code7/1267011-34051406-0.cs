    public class RhinoMocks_33901386
    {
        //public static ITypeHelper TypeHelper = new TypeHelper();
        //use when testing
        public static ITypeHelper TypeHelper = new MockTypeHelper();
        public static void Run()
        {
            var validator = MockRepository.GenerateMock<IValidator<string>>();
            validator.Expect(v => v.Validate(Arg<string>.Is.Equal("input"))).Return(true);
            var method = TypeHelper.GetMethod(validator.GetType(), "Validate");
            var result = (bool) method.Invoke(validator, new object[] {"input"});
            Console.WriteLine(result);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
    public interface IValidator<in T>
    {
         bool Validate(T obj);
    }
    public interface ITypeHelper
    {
        MethodInfo GetMethod(Type self, string name);
    }
    public class TypeHelper : ITypeHelper
    {
        public virtual MethodInfo GetMethod(Type self, string name)
        {
            return self.GetMethod(name);
        }
    }
    public class MockTypeHelper : ITypeHelper
    {
        public virtual MethodInfo GetMethod(Type self, string name)
        {
            if (typeof(IMockedObject).IsAssignableFrom(self) && self.BaseType == typeof(object))
            {
                self = self.GetInterfaces()
                    .First(x => x != typeof(IMockedObject) && x != typeof(ISerializable) && x != typeof(IProxyTargetAccessor));
            }
            return self.GetMethod(name);
        }
    }
