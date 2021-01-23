    public T Get<T>(Func<T, bool> predicate)
        where T : class
    {
        T item = null;
        using (var context = MyContext())
        {
            item = context.Set<T>().FirstOrDefault(predicate);
        }
        return item;
    }
    var customer = context.Get<Customer>(x => x.Name == "Bob");
