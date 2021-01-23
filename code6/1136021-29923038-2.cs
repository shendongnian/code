    public class MyTypeListControl : UserControl
    {
        private ObservableCollection<MyType> _Items;
        public MyTypeListControl()
        {
            AutoScroll = true;
            _Items = new ObservableCollection<MyType>();
            _Items.CollectionChanged += OnItemsCollectionChanged;
        }
        public Collection<MyType> Items
        {
            get { return _Items; }
        }
        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateVisualization();
        }
        private void UpdateVisualization()
        {
            SuspendLayout();
            Controls.Clear();
            foreach (var item in _Items)
            {
                var control = new MyTypeControl { MyType = item, Dock = DockStyle.Top };
                Controls.Add(control);
                Controls.SetChildIndex(control, 0);
            }
            ResumeLayout();
        }
    }
