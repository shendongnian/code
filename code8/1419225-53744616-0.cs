    public class ListViewHeightBehavior : Behavior<ListView>
    {
        private ListView _listView;
        public static readonly BindableProperty ExtraSpaceProperty =
            BindableProperty.Create(nameof(ExtraSpace),
                                    typeof(double),
                                    typeof(ListViewHeightBehavior),
                                    0d);
        public static readonly BindableProperty DefaultRowHeightProperty =
            BindableProperty.Create(nameof(DefaultRowHeight),
                              typeof(int),
                              typeof(ListViewHeightBehavior),
                              40);
        public int DefaultRowHeight
        {
            get => (int)GetValue(DefaultRowHeightProperty);
            set => SetValue(DefaultRowHeightProperty, value);
        }
        public double ExtraSpace
        {
            get { return (double)GetValue(ExtraSpaceProperty); }
            set { SetValue(ExtraSpaceProperty, value); }
        }
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            _listView = bindable;
            _listView.PropertyChanged += (s, args) =>
            {
                var count = _listView.ItemsSource?.Cast<object>()?.Count();
                if (args.PropertyName == nameof(_listView.ItemsSource)
                        && count.HasValue
                        && count.Value > 0)
                {
                    int rowHeight = _listView.RowHeight > 0 ? _listView.RowHeight : DefaultRowHeight;
                    _listView.HeightRequest = rowHeight * count.Value + ExtraSpace;
                }
            };
        }
    }
