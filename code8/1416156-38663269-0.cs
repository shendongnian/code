    static void Main()
        {
            var list = new MyObservableCollection<int>(10, 10);
            list.ConditionReachedEvent += () =>
            {
                //Do something
            };
            list.StartTimer();
            Task.Factory.StartNew(
                () =>
                    {
                        // Simulate slow operation
                        Thread.Sleep(12000);
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
            private System.Threading.Timer timer;
            private readonly int alertThreshold;
            private long isEventRaised = 0;
            private readonly int timeout = 0;
            public MyObservableCollection(int alertThreshold, int timeout)
            {
                this.alertThreshold = alertThreshold;
                this.timeout = timeout * 1000;
            }
            public void StartTimer()
            {
                Interlocked.Exchange(ref this.isEventRaised, 0);
                this.StopTimer();
                this.timer = new Timer(x =>
                {
                    this.RaiseEvent();
                }, null, this.timeout, this.timeout);
            }
            private void StopTimer()
            {
                if (this.timer != null)
                {
                    this.timer.Dispose();
                    this.timer = null;
                }
            }
            protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                base.OnCollectionChanged(e);
                if (this.Count >= this.alertThreshold)
                {
                    this.RaiseEvent();
                }
            }
            private void RaiseEvent()
            {
                this.StopTimer();
                if (Interlocked.CompareExchange(ref this.isEventRaised, 1, 0) != 0)
                {
                    return;
                }
                this.ConditionReachedEvent();
            }
        }
