    public class ProxyCollection<TProxy, TSource> : IEnumerable<TProxy>, IDisposable{
        private readonly Dictionary<TSource, TProxy> _map = new Dictionary<TSource, TProxy>();
        private readonly Func<TSource, TProxy> _proxyFactory;
        private readonly ObservableCollection<TSource> _sourceCollection;
        public ProxyCollection(ObservableCollection<TSource> sourceCollection, Func<TSource, TProxy> proxyFactory){
            _sourceCollection = sourceCollection;
            _proxyFactory = proxyFactory;
            AddItems(sourceCollection);
            _sourceCollection.CollectionChanged += OnSourceCollectionChanged;
        }
        public IEnumerator<TProxy> GetEnumerator(){
            return _map.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }
        private void AddItems(IEnumerable<TSource> sourceCollection){
            foreach (TSource sourceItem in sourceCollection){
                AddProxy(sourceItem);
            }
        }
        private void AddProxy(TSource source){
            _map[source] = _proxyFactory(source);
        }
        private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e){
            switch (e.Action){
                case NotifyCollectionChangedAction.Add:
                    AddItems(e.NewItems.Cast<TSource>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveItems(e.OldItems.Cast<TSource>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    ReplaceItems(e.OldItems.Cast<TSource>(), e.NewItems.Cast<TSource>());
                    break;
                case NotifyCollectionChangedAction.Move:
                    throw new NotImplementedException("Your code here");
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException("Your code here");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void ReplaceItems(IEnumerable<TSource> oldItems, IEnumerable<TSource> newItems){
            RemoveItems(oldItems);
            AddItems(newItems);
        }
        private void RemoveItems(IEnumerable<TSource> sourceItems){
            foreach (TSource sourceItem in sourceItems){
                _map.Remove(sourceItem);
            }
        }
        public void Dispose(){
            _sourceCollection.CollectionChanged -= OnSourceCollectionChanged;
            //optionally
            foreach (IDisposable proxy in _map.Values.OfType<IDisposable>()){
                proxy.Dispose();
            }
        }
    }
