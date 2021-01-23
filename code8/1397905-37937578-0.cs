        /// <summary>
        /// Subscribes to the observable sequence and manages the disposables 
        /// with a serial disposable. That
        /// is before the function is called again the previous disposable is disposed.
        /// </summary>
        public static IDisposable SubscribeDisposable<T>
        (this IObservable<T> o, Func<T, IDisposable> fn, Action<Exception> errHandler)
        {
            var d = new SerialDisposable();
            var s = o.Subscribe(v =>
            {
                    d.Disposable = Disposable.Empty;
                    d.Disposable = fn(v) ?? Disposable.Empty;
            }, onError:errHandler);
            return new CompositeDisposable(s,d);
        }
