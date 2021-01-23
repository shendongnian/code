     interface IGenericClass<out T> where T : IType
     {
        T GetType(); //possible
        void SetType(T t); //not possible
     }
