    class StatusValueConverter : IValueConverter
    {
        private static SolidColorBrush _acceptedBrush = new SolidColorBrush(Colors.Green);
        private static SolidColorBrush _pendingBrush = new SolidColorBrush(Colors.Yellow);
        private static SolidColorBrush _rejectedBrush = new SolidColorBrush(Colors.Red);
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush brush = null;
            if (value != null)
            {
                string status = value.ToString();
                switch (status)
                {
                    case "Accepted":
                        brush = _acceptedBrush;
                        break;
                    case "Pending":
                        brush = _pendingBrush;
                        break;
                    case "Rejected":
                        brush = _rejectedBrush;
                        break;
                }
            }
            if (brush == null)
            {
                throw new ArgumentException("Status not valid.");
            }
            return brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // You need this if TwoWay binding mode is used.
        }
    }
