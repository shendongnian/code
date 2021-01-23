            #region CountFor attached property
        
                
            public static bool GetCountFor(DependencyObject obj)
            {
                return (bool)obj.GetValue(CountForProperty);
            }
            public static void SetCountFor(DependencyObject obj, bool value)
            {
                obj.SetValue(CountForProperty, value);
            }
            // Using a DependencyProperty as the backing store for CountFor.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CountForProperty =
                DependencyProperty.RegisterAttached("CountFor", typeof(bool), typeof(Window2), new PropertyMetadata(false, new PropertyChangedCallback(GetCountForChanged)));
            private static void GetCountForChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if ((bool)e.NewValue == false) return;
                Label lbl = (Label)d;
                lbl.Loaded += (o, args) =>
                {
                    DependencyObject parent = VisualTreeHelper.GetParent(lbl);
                    while (parent.GetType() != typeof(ListBox))
                        parent = VisualTreeHelper.GetParent(parent);
                    ListBox lb = (ListBox)parent;
                    ICollectionView view = CollectionViewSource.GetDefaultView(lb.ItemsSource);
                    lbl.Content = "Number of items = " + ((ListCollectionView)view).Count;
                    view.CollectionChanged += (col, colargs) =>
                    {
                        lbl.Content = "Number of items = " + ((ListCollectionView)col).Count;
                        System.Diagnostics.Debug.WriteLine(((ListCollectionView)col).Count.ToString());
                    };
                };
            }
            #endregion  
