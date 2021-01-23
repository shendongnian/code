        public class BytesToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            using (InMemoryRandomAccessStream raStream = new InMemoryRandomAccessStream())
            {
                return new TaskCompletionNotifier<BitmapImage>(GetImageFromByteArray((String)value));
            }
        }
    }
