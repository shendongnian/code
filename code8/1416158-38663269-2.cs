     static void Main()
            {
                var list = new MyObservableCollection<int>(10);
                list.ConditionReachedEvent += () =>
                 {
    
                 };
    
                list.Start(10);
    
                Task.Run(
                    () =>
                    {
                        // Simulate slow operation
                        Thread.Sleep(TimeSpan.FromSeconds(12));
                        for (var i = 0; i < 10; i++)
                        {
                            list.Add(i);
                        }
                    });
    
                Console.Read();
            }
    
    
            public sealed class MyObservableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>
            {
                public event Action ConditionReachedEvent = delegate { };
                private readonly int alertThreshold;
                private readonly TaskCompletionSource<object> capacityReached = new TaskCompletionSource<object>();
    
                public MyObservableCollection(int alertThreshold)
                {
                    this.alertThreshold = alertThreshold;
                }
    
                public async void Start(int timeout)
                {
                    var timeoutTask = Task.Delay(TimeSpan.FromSeconds(timeout));
                    var capacityReachedTask = capacityReached.Task;
    
                    await Task.WhenAny(capacityReachedTask, timeoutTask);
                    this.ConditionReachedEvent();
                }
    
                protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    base.OnCollectionChanged(e);
                    if (this.Count >= this.alertThreshold)
                    {
                        capacityReached.TrySetResult(null);
                    }
                }
            }
