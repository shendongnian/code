        public class TileAttachedProperties
    {
        public static readonly DependencyProperty IsTyleTypeBoundProperty = DependencyProperty.RegisterAttached(
            "IsTyleTypeBound",
            typeof (bool),
            typeof (TileAttachedProperties),
            new PropertyMetadata(default(bool), IsTyleBoundPropertyChangedCallback));
        private static void IsTyleBoundPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var tile = sender as Tile;
            var isBound = (bool) args.NewValue;
            if(tile == null || isBound == false) return;
            tile.Loaded += TileOnLoaded;
        }
        private static void TileOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var tile = sender as Tile;
            if (tile == null) return;
            tile.Loaded -= TileOnLoaded;
            var tileContent = tile.Content;
            if (tileContent == null || tileContent is ItemTypeWrapper == false) return;
            var binding = new Binding("IsDouble");
            binding.Source = tileContent;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.Converter = new Bool2TileTypeConverter();
            tile.SetBinding(Tile.TileTypeProperty, binding);
        }
        public static void SetIsTyleTypeBound(DependencyObject element, bool value)
        {
            element.SetValue(IsTyleTypeBoundProperty, value);
        }
        public static bool GetIsTyleTypeBound(DependencyObject element)
        {
            return (bool) element.GetValue(IsTyleTypeBoundProperty);
        } 
    }
    internal class Bool2TileTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isDouble = (bool) value;
            return isDouble ? TileType.Double : TileType.Single;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class TileContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Mail { get; set; }
        public DataTemplate Market { get; set; }
        public DataTemplate Contacts { get; set; }
        public DataTemplate Weather { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dataTemplate;
            var model = item as ItemTypeWrapper;
            if (model == null) 
                return null;
            var key = model.ItemType;
            switch (key)
            {
                case ItemType.Mail:
                    dataTemplate = Mail;
                    break;
                case ItemType.Market:
                    dataTemplate = Market;
                    break;
                case ItemType.Contacts:
                    dataTemplate = Contacts;
                    break;
                case ItemType.Weather:
                    dataTemplate = Weather;
                    break;
                default:
                    throw  new ArgumentOutOfRangeException();
            }
            return dataTemplate;
        }
    }
