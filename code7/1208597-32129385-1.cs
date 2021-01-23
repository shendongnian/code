    public A<T> FactoryMethod<T>(openT i)
    {
       if(i == openT.level1)
          return new A<T>():
    
       if(i == openT.level2)
          return new B<T>():
    
    }
    public A<D> FactoryMethod()
    {
        return new C():
    }
    public static void Main()
    {
        A<string> first = OpenFactoryMethod<string>(1);
        A<int> second = OpenFactoryMethod<int>(2);
        A<D> third = FactoryMethod();
    }
