    public class DynamicFactory<T>  
    {
        public static T Create(string className)
        {
            Type t = typeof(T);
            return (T)Activator.CreateInstance(
                        t.Assembly.FullName, 
                        t.Namespace + "." + className
                      ).Unwrap();
        }
    }
    namespace Brands
    {
        public class CarBrand { }
        // The brands should be in the same namespace and assembly with CarBrand
        // and should inherit from CarBrand
        public class Toyota : CarBrand { };
        public class Bmw : CarBrand { };
        public class Mercedes : CarBrand { };
        public class Titanic { } // this one is not CarBrand
        class BrandFactory: DynamicFactory<CarBrand> { }
        // Below are unit tests using NUnit
        namespace BrandFactorySpecification 
        {
            static class Create
            {
                [TestCase("Toyota", Result = typeof(Toyota))]
                [TestCase("Bmw", Result = typeof(Bmw))]
                [TestCase("Mercedes", Result = typeof(Mercedes))]
                [TestCase("Titanic", ExpectedException = typeof(InvalidCastException))]
                [TestCase("unknown", ExpectedException = typeof(TypeLoadException))]
                [TestCase("String", ExpectedException = typeof(TypeLoadException))]
                [TestCase("System.String", ExpectedException = typeof(TypeLoadException))]
                [TestCase("ACarBrandFromAnotherNamespace", 
                              ExpectedException = typeof(TypeLoadException))]
                [TestCase("AnotherNamespace.ACarBrandFromAnotherNamespace",
                              ExpectedException = typeof(TypeLoadException))]
                //
                public static Type ShouldReturnCorrectType(string brandName)
                {
                    return BrandFactory.Create(brandName).GetType();
                }
                [Test]
                public static void ForTitanic()
                {
                    DynamicFactory<Titanic>.Create("Titanic")
                        .ShouldBeType(typeof(Titanic));
                }
            }
            namespace AnotherNamespace
            {
                public class ACarBrandFromAnotherNamespace : CarBrand { };
            }
        }
    }
