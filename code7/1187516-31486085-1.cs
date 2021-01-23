        public static IObservable<TResult> Generate<TResult>(
            Func<Task<TResult>> initialState,
            Func<TResult, bool> condition,
            Func<TResult, Task<TResult>> iterate,
            Func<TResult, TResult> resultSelector
            )
        {
            return Observable.Create<TResult>(async obs =>
            {
                var state = await initialState();
                while (condition(state))
                {
                    var result = resultSelector(state);
                    obs.OnNext(result);
                    state = await iterate(state);
                }
                    
                obs.OnCompleted();
                return System.Reactive.Disposables.Disposable.Empty;
            });
        }
