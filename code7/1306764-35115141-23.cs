        public class WorkerToColorConverter : IValueConverter
        {
            public Brush ChefColor { get; set; }
            public Brush WaiterColor { get; set; }
            public Brush DefaultColor { get; set; }
    
            public WorkerToColorConverter()
            {
                //Default Colors
                ChefColor = Brushes.Aqua;
                WaiterColor = Brushes.Yellow;
                DefaultColor = Brushes.Transparent;
            }
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var workerName = value as string;
                switch (workerName)
                {
                    case "Chef":
                        return ChefColor;
                    case "Waiter":
                        return WaiterColor;
                    default:
                        return DefaultColor;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
