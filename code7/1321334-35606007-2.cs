    public IEnumerable<T> Existed<T>(IEnumerable<T> p2) // where T : IBase<U>
    {
      if (typeof(T) == typeof(Class1)) {
        IQueryable<ICollection<T>> p1 = null;
        return NewMethod<Class1, int>( // Type parameter are assigned
            p1 as IQueryable<ICollection<Class1>>,
            p2 as IEnumerable<Class1>
        ) as IEnumerable<T>;
      }
    }
