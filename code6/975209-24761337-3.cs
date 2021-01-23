    #region
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading;
    #endregion
    internal class Program
    {
        #region Methods
        private static void Main(string[] args)
        {
            var autoReset = new AutoResetEvent(false);
            var r = new Random();
            var o = new ObservableCollection<DataPoint>();
            o.CollectionChanged += o_CollectionChanged;
            var subscription1 = Observable.Interval(TimeSpan.FromSeconds(1)).Take(3).Subscribe(
                i =>
                {
                    o.Add(
                        new DataPoint
                        {
                            ItemCount = r.Next(100)
                        });
                    Console.WriteLine("Fire1 {0}", i);
                });
            var subscription3 = Observable.Interval(TimeSpan.FromSeconds(1)).Delay(TimeSpan.FromSeconds(3)).Take(3).Finally(
                () =>
                {
                    o.Clear();
                    autoReset.Set();
                }).Subscribe(
                    i =>
                    {
                        if (o.Any())
                        {
                            o[r.Next(o.Count)].ItemCount = r.Next(100);
                        }
                        Console.WriteLine("Fire3 {0}", i);
                    });
            autoReset.WaitOne();
            o.CollectionChanged -= o_CollectionChanged;
        }
        private static void o_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) { Console.WriteLine("Collection changed event!"); }
        #endregion
        private class DataPoint
        {
            #region Public Properties
            public int ItemCount { get; set; }
            #endregion
        }
    }
