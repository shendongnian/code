    class TaskObservable<T> : IObservable<T>
    {
        private class ObserverItem : IDisposable
        {
            public readonly IObserver<T> Observer;
            public readonly TaskObservable<T> Owner;
            public ObserverItem(IObserver<T> observer, TaskObservable<T> owner)
            {
                Observer = observer;
                Owner = owner;
            }
            public void Dispose()
            {
                if (!Owner._observerItems.Contains(this))
                {
                    throw new InvalidOperationException(
                        "This observer is no longer subscribed");
                }
                Owner._observerItems.Remove(this);
            }
        }
        private readonly Task<T>[] _tasks;
        private readonly List<ObserverItem> _observerItems = new List<ObserverItem>();
        public TaskObservable(Task<T>[] tasks)
        {
            _tasks = tasks;
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            ObserverItem item = new ObserverItem(observer, this);
            _observerItems.Add(item);
            return item;
        }
        private void Publish(T t)
        {
            foreach (ObserverItem item in _observerItems)
            {
                item.Observer.OnNext(t);
            }
        }
        private void Complete()
        {
            foreach (ObserverItem item in _observerItems)
            {
                item.Observer.OnCompleted();
            }
        }
        async Task Run()
        {
            for (int i = 0; i < _tasks.Length; i++)
            {
                Task<T> completedTask = await Task.WhenAny(tasks);
                Publish(completedTask.Result);
            }
            Complete();
        }
    }
