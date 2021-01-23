    public static IDisposable AsLazyComposite(this IEnumerable<IDisposable> sequence)
    {
        return Disposable.Create(() =>
        {
            foreach (var disposable in sequence)
                disposable.Dispose();
        });
    }
