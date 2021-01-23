        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Model.ListParameters parameters = (Model.ListParameters)value;
            if(parameters !=null)
            {
                var start = new GradientStop();
                start.Color = Colors.Green;
                start.Offset = 0;
                var stop = new GradientStop();
                stop.Color = (Color)ColorConverter.ConvertFromString("#FF2D2D30");
                stop.Offset = parameters .Percent;
                var result = new LinearGradientBrush();
                result.StartPoint = new Point(0, 0);
                result.EndPoint = new Point(1, 0);
                result.GradientStops.Add(start);
                result.GradientStops.Add(stop);
                return result;
            }
            return null;
        }
