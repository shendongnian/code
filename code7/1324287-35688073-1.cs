    public partial class AsyncListUserControl : UserControl
    {
        public static DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable), typeof(AsyncListUserControl), new PropertyMetadata(null, OnItemsChanged));
        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AsyncListUserControl control = d as AsyncListUserControl;
            control.InitializeItemsAsync(e.NewValue as IEnumerable);
        }
        private CancellationTokenSource _itemsLoadiog = new CancellationTokenSource();
        private readonly object _itemsLoadingLock = new object();
        public IEnumerable Items
        {
            get
            {
                return (IEnumerable)this.GetValue(ItemsProperty);
            }
            set
            {
                this.SetValue(ItemsProperty, value);
            }
        }
        
        public AsyncListUserControl()
        {
            InitializeComponent();
        }
        private void InitializeItemsAsync(IEnumerable items)
        {
            lock(_itemsLoadingLock)
            {
                if (_itemsLoadiog!=null)
                {
                    _itemsLoadiog.Cancel();
                }
                _itemsLoadiog = new CancellationTokenSource();
            }
            listView.IsEnabled = false;
            itemsLoadingIndicator.Visibility = Visibility.Visible;
            this.listView.Items.Clear();
            ItemsLoadingState state = new ItemsLoadingState(_itemsLoadiog.Token, this.Dispatcher, items);
            Task.Factory.StartNew(() =>
            {
                int pendingItems = 0;
                ManualResetEvent pendingItemsCompleted = new ManualResetEvent(false);
                foreach(object item in state.Items)
                {
                    if (state.CancellationToken.IsCancellationRequested)
                    {
                        pendingItemsCompleted.Set();
                        return;
                    }
                    Interlocked.Increment(ref pendingItems);
                    pendingItemsCompleted.Reset();
                    state.Dispatcher.BeginInvoke(
                        DispatcherPriority.Background,
                        (Action<object>)((i) =>
                        {
                            if (state.CancellationToken.IsCancellationRequested)
                            {
                                pendingItemsCompleted.Set();
                                return;
                            }
                            this.listView.Items.Add(i);
                            if (Interlocked.Decrement(ref pendingItems) == 0)
                            {
                                pendingItemsCompleted.Set();
                            }
                        }), item);
                }
                pendingItemsCompleted.WaitOne();
                state.Dispatcher.Invoke(() =>
                {
                    if (state.CancellationToken.IsCancellationRequested)
                    {
                        pendingItemsCompleted.Set();
                        return;
                    }
                    itemsLoadingIndicator.Visibility = Visibility.Collapsed;
                    listView.IsEnabled = true;
                });
            });
        }
        private class ItemsLoadingState
        {
            public CancellationToken CancellationToken { get; private set; }
            public Dispatcher Dispatcher { get; private set; }
            public IEnumerable Items { get; private set; }
            public ItemsLoadingState(CancellationToken cancellationToken, Dispatcher dispatcher, IEnumerable items)
            {
                CancellationToken = cancellationToken;
                Dispatcher = dispatcher;
                Items = items;
            }
        }
    }
