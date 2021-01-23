        static IObservable<int> ColdSource()
        {
            return Observable.Create<int>(subscriber =>
            {
                for (int i = 0; i <= 100; ++i)
                {
                    subscriber.OnNext(i);
                }
                subscriber.OnCompleted();
                return Disposable.Empty;
            });
        }
