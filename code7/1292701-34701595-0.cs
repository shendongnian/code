    using System;
    using System.Linq;
    
    namespace ConsoleApplication {
    
      public class GenericClass<T> {
        public void ArrayMethod(T[] parameter) { }
        public void ReferenceMethod(ref T parameter) { }
      }
    
      public class AnotherGenericClass<T> : GenericClass<T> { }
    
      public static class Program {
    
        public static void Main(string[] args) {
          GenericTypeParameter();
          ArrayType();
          PointerType();
          ByRefTypeBasedOnTypeParameter();
          NongenericTypeDefinitionWithUnresolvedTypeParameters();
          Console.ReadKey();
        }
    
        public static void GenericTypeParameter() {
          var type = typeof(GenericClass<>)
            .GetGenericArguments()
            .First();
          PrintFullName("Generic type parameter", type);
        }
    
        public static void ArrayType() {
          var type = typeof(GenericClass<>)
            .GetMethod("ArrayMethod")
            .GetParameters()
            .First()
            .ParameterType;
          PrintFullName("Array type based on type parameter", type);
        }
    
        /*
         * Would like an actual example of a pointer to a generic type,
         * but this works for now.
         */
        public static void PointerType() {
          var type = typeof(GenericClass<>)
            .GetGenericArguments()
            .First()
            .MakePointerType();
          PrintFullName("Pointer type based on type parameter", type);
        }
    
        public static void ByrefTypeBasedOnTypeParameter() {
          var type = typeof(GenericClass<>)
            .GetMethod("ReferenceMethod")
            .GetParameters()
            .First()
            .ParameterType;
          PrintFullName("ByRef type based on type parameter", type);
        }
    
        private static void NongenericTypeDefinitionWithUnresolvedTypeParameters() {
          var type = typeof(AnotherGenericClass<>).BaseType;
          PrintFullName("Nongeneric type definition with unresolved type parameters", type);
        }
    
        public static void PrintFullName(string name, Type type) {
          Console.WriteLine(name + ":");
          Console.WriteLine("--Name: " + type.Name);
          Console.WriteLine("--FullName: " + (type.FullName ?? "null"));
          Console.WriteLine();
        }
      }
    }
    
    /***Output***
    Generic type parameter:
    --Name: T
    --FullName: null
    
    Array type based on type parameter:
    --Name: T[]
    --FullName: null
    
    Pointer type based on type parameter:
    --Name: T*
    --FullName: null
    
    Byref type based on type parameter:
    --Name: T&
    --FullName: null
    
    Nongeneric type definition with unresolved type parameters:
    --Name: GenericClass`1
    --FullName: null
    ***Output***/
