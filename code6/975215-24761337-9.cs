    namespace ConsoleApplication1
    {
        #region
    
        using System;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
        using System.ComponentModel;
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
                var o = new TrulyObservableCollection<DataPoint>();
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
                var subscription2 =
                    Observable.FromEventPattern<NotifyCollectionChangedEventArgs>(o, "CollectionChanged")
                        .Subscribe(s => { Console.WriteLine("List changed. Current total {0}", o.Sum(s1 => s1.ItemCount)); });
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
                                Console.WriteLine("Fire3 {0}", i);
                            }
                        });
                autoReset.WaitOne();
            }
    
            #endregion
    
            public class TrulyObservableCollection<T> : ObservableCollection<T>
                where T : INotifyPropertyChanged
            {
                #region Constructors and Destructors
    
                public TrulyObservableCollection() { CollectionChanged += this.TrulyObservableCollection_CollectionChanged; }
    
                #endregion
    
                #region Methods
    
                private void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.NewItems != null)
                    {
                        foreach (Object item in e.NewItems)
                        {
                            (item as INotifyPropertyChanged).PropertyChanged += this.item_PropertyChanged;
                        }
                    }
                    if (e.OldItems != null)
                    {
                        foreach (Object item in e.OldItems)
                        {
                            (item as INotifyPropertyChanged).PropertyChanged -= this.item_PropertyChanged;
                        }
                    }
                }
    
                private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
                {
                    var a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                    OnCollectionChanged(a);
                }
    
                #endregion
            }
    
            private class DataPoint : INotifyPropertyChanged
            {
                #region Fields
    
                private int itemCount;
    
                #endregion
    
                #region Public Events
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                #endregion
    
                #region Public Properties
    
                public int ItemCount
                {
                    get { return itemCount; }
                    set
                    {
                        itemCount = value;
                        this.OnPropertyChanged("ItemCount");
                    }
                }
    
                #endregion
    
                #region Methods
    
                protected virtual void OnPropertyChanged(string propertyName = null)
                {
                    var handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
    
                #endregion
            }
        }
    }
