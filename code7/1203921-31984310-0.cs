    interface IType { }
    interface IGenericClass { }
    class Type1 : IType { }
    class Type2 : IType { }
    class GenericClass<T> : IGenericClass where T : IType { }
    class Program
    {
        static void Main(string[] args)
        {
            var gen1 = new GenericClass<Type1>();
            var gen2 = new GenericClass<Type2>();
            var list = new List<IGenericClass>();
            list.Add(gen1);
            list.Add(gen2);
        }
    }
