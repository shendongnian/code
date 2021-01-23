    public TAofT FactoryMethod<TAofT, T>() where TAofT : A<T>, new()
    {
        return new TAofT():
    }
    public static void Main()
    {
        A<string> first = FactoryMethod<A<string>, string>();
        A<int> second = FactoryMethod<B<int>, int>();
        A<D> third = FactoryMethod<C, D>();
    }
