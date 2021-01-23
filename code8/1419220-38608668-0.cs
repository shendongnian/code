    public class ListViewHeightBehavior : Behavior<ListView>
    {
        private ListView _listView;
        public static readonly BindableProperty ExtraSpaceProperty =
            BindableProperty.Create(nameof(ExtraSpace),
                                    typeof(double),
                                    typeof(ListViewHeightBehavior),
                                    0d);
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
                var count = _listView.ItemsSource?.Count();
                if (args.PropertyName == nameof(_listView.ItemsSource)
                        && count.HasValue
                        && count.Value > 0)
                {
                    _listView.HeightRequest = _listView.RowHeight * count.Value + ExtraSpace;
                }
            };
        }
    }
         <ListView ItemsSource="{Binding Items}"
                   HasUnevenRows="True">
          <ListView.Behaviors>
            <behaviors:ListViewHeightBehavior ExtraSpace="180"/>
          </ListView.Behaviors>
          <ListView.ItemTemplate>
            <DataTemplate>
              <ViewCell>
                 // Your template
              </ViewCell>
            </DataTemplate>
          </ListView.ItemTemplate>
        </ListView>
