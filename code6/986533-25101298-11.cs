    public static class SubjectEx
    {
        public static class OnNextEmpty<T>(this ISubject<IObservable<T>> subject)
       {
           subject.OnNext(Observable.Empty<T>());
       }
    }
