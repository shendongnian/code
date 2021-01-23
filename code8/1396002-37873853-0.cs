    using System;
    using System.Linq;
    using System.Reflection;
    
    class Foo
    {
        public int Value { get; set; }        
        public static explicit operator Bar(Foo x) => new Bar { Value = x.Value };
        public static explicit operator Foo(Bar x) => new Foo { Value = x.Value };
    }
    
    class Bar
    {
        public int Value { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var foo = new Foo { Value = 10 };
            var bar = Convert<Bar>(foo);
            Console.WriteLine(bar.Value);
            foo = Convert<Foo>(bar);
            Console.WriteLine(foo.Value);        
        }
        
        public static T Convert<T>(object source)
        {
            var conversion = FindConversion(source.GetType(), typeof(T));
            if (conversion == null)
            {
                throw new InvalidOperationException("No conversion found");
            }
            return (T) conversion.Invoke(null, new[] { source });
        }
        
        private static MethodInfo FindConversion(Type fromType, Type toType)
        {
            var expectedParameterTypes = new[] { fromType };
            var methods = from type in new[] { fromType, toType }
                          from method in type.GetMethods(BindingFlags.Public | BindingFlags.Static)
                          where method.Name == "op_Explicit" || method.Name == "op_Implicit"
                          where (method.Attributes & MethodAttributes.SpecialName) != 0
                          where method.ReturnType == toType
                          where method.GetParameters()
                                      .Select(p => p.ParameterType)
                                      .SequenceEqual(expectedParameterTypes)
                          select method;
            return methods.FirstOrDefault();
        }
    }
