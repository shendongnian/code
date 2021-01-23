    public static IObservable<T> HotConcat<T>(this IObservable<T> first, IObservable<T> second)
    {
        return Observable.Create<T>(observer =>
        {
            var queue = new Queue<Notification<T>>();
            var secondSubscription = second.Materialize().Subscribe(item =>
            {
                if (queue == null)
                    return;
                lock (queue)
                {
                    queue.Enqueue(item);
                }
            });
            var secondReplay = Observable.Create<T>(secondObserver =>
            {
                while (true)
                {
                    Notification<T> item = null;
                    lock (queue)
                    {
                        if (queue.Count > 0)
                        {
                            item = queue.Dequeue();
                        }
                    }
                    if (item != null)
                    {
                        item.Accept(secondObserver);
                    }
                    else
                    {
                        secondObserver.OnCompleted();
                        secondSubscription.Dispose();
                        queue = null;
                        break;
                    }
                }
                return secondSubscription;
            });
            return first.Concat(secondReplay).Concat(second).Subscribe(observer);
        });
    }
