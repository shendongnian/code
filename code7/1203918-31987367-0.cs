        public static IObservable<T> ToObservable<T>(Task<T> task, TaskScheduler scheduler)
        {
            if (task.IsCompleted)
            {
                return task.ToObservable();
            }
            else
            {
                AsyncSubject<T> asyncSubject = new AsyncSubject<T>();
                task.ContinueWith(t => task.ToObservable().Subscribe(asyncSubject), scheduler);
                return asyncSubject.AsObservable<T>();
            }
        }
