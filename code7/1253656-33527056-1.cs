    public partial class BindableMap : UserControl
    {
        public ObservableCollection<Pushpin> Pins
        {
            get { return (ObservableCollection<Pushpin>)GetValue(PinsProperty); }
            set { SetValue(PinsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Pins.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PinsProperty =
            DependencyProperty.Register("Pins", typeof(ObservableCollection<Pushpin>), typeof(BindableMap),
            new PropertyMetadata(null, new PropertyChangedCallback(OnPinsChanged)));
        private static void OnPinsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BindableMap map = (BindableMap)d;
            //If the pin collection changes, then reset the map view.
            map.ClearMapPoints();
            map.SubscribeToCollectionChanged();
        }
        private void ClearMapPoints()
        {
            map.Children.Clear();
        }
        private void SubscribeToCollectionChanged()
        {
            if (Pins != null)
                Pins.CollectionChanged += Pins_CollectionChanged;
        }
        private void Pins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Remove the old pushpins
            if (e.OldItems != null)
                foreach (Pushpin pin in e.OldItems)
                    map.Children.Remove(pin);
            //Add the new pushpins
            if (e.NewItems != null)
                foreach (Pushpin pin in e.NewItems)
                    map.Children.Add(pin);
        }
        public BindableMap()
        {
            InitializeComponent();
            Pins = new ObservableCollection<Pushpin>();
        }
        private void Map_DoubleClicked(object sender, MouseButtonEventArgs e)
        {
            //Get the current position of the mouse.
            Point point = Mouse.GetPosition(map);
            //Create the pin.
            Pushpin pin = new Pushpin();
            pin.Location = map.ViewportPointToLocation(point);
            //Add the pin to the map.
            Pins.Add(pin);
        }
    }
