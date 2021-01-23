    public static class ObservableExtensions
    {
        public static IObservable<TResult> Let(this IObservable<T> source, Func<IObservable<T>, IObservable<TResult>> let)
        {
            return let(source);
        }
        public static IObservable<TResult> Let(this IObservable<T> source, IStep<T, TResult> step)
        {
          return source.Let(step.Transform);
        }
    }
