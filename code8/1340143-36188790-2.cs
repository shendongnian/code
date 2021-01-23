    public CustomControl()
            {
                this.InitializeComponent();
                LayoutRoot.DataContext = this;
            }
    
    
    
            public List<Model> ItemsSource
            {
                get { return (List<Model>)GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(List<Model>), typeof(CustomControl), new PropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));
    
            private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
    
            }
        }
