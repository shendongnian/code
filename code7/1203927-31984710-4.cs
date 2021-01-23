    interface IType { }
    interface IGenericClass<out T> where T : IType { }
    class Type1 : IType { }
    class Type2 : IType { }
    class GenericClass<T> : IGenericClass<T> where T : IType { }
    class Program
    {
        static void Main(string[] args)
        {
             Dictionary<int, IGenericClass<IType>> dict = new Dictionary<int, IGenericClass<IType>>();
                    dict[0] = new GenericClass<Type2>();
                    dict[1] = new GenericClass<Type1>();
         }
    }
