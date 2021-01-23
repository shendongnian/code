    public static class Disposable
    {
        public static TResult Using<TResult>(
            Func<IDisposable> factory,
            Func<IDisposable, TResult> use)
       {
            using (var disposable = factory())
            {
                 return use(disposable);
            }
       }
    }
