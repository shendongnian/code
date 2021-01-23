        public class WorkerToColorMultiConverter : IMultiValueConverter
        {
            public Brush ChefColor { get; set; }
            public Brush WaiterColor { get; set; }
            public Brush DefaultColor { get; set; }
    
            public WorkerToColorMultiConverter()
            {
                //Default Colors
                ChefColor = Brushes.Aqua;
                WaiterColor = Brushes.Yellow;
                DefaultColor = Brushes.Transparent;
            }
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values != null && values.Count() == 2)
                {
                    var cellValue = values[0] as string;
                    var workerValue = values[1] as string;
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        switch (workerValue)
                        {
                            case "Chef":
                                return ChefColor;
                            case "Waiter":
                                return WaiterColor;
                            default:
                                return DefaultColor;
                        }
                    }
                }
                return DefaultColor;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
