    public class ItemToIndexConverter : IValueConverter
    {
        public object Convert(...)
        {
            CollectionViewSource itemSource = parameter as CollectionViewSource;
            IEnumerable<object> items = itemSource.Source as IEnumerable<object>;
            return items.IndexOf(value as object);
        }
        public object ConvertBack(...)
        {
            return Binding.DoNothing;
        }
    }
