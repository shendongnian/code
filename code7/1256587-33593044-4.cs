    public sealed partial class MyUserControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IList), typeof(MyUserControl),
                new PropertyMetadata(0, (s, e) =>
                {
                    if (Math.Sqrt((e.NewValue as IList).Count) % 1 != 0)
                        Debug.WriteLine("Bad Collection");
                }));
        public void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Math.Sqrt(Items.Count) % 1 != 0) Debug.WriteLine("Bad Collection");
            RaiseProperty(nameof(ElementSize));
        }
        private double currentWidth;
        public double CurrentWidth
        {
            get { return currentWidth; }
            set { currentWidth = value; RaiseProperty(nameof(CurrentWidth)); RaiseProperty(nameof(ElementSize)); }
        }
        public double ElementSize => (int)(currentWidth / (int)Math.Sqrt(Items.Count)) - 1;
        public MyUserControl()
        {
            this.InitializeComponent();
        }
    }
