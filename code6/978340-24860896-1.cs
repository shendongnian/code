    namespace CSharpWPF
    {
        class PointConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                XmlElement curve = value as XmlElement;
                PointCollection pc = new PointCollection();
                int x = 0;
                int increment = int.Parse(curve.Attributes["xstep"].Value);
                foreach (XmlElement item in curve.ChildNodes)
                {
                    pc.Add(new Point(x, int.Parse(item.Attributes["Value"].Value)));
                    x += increment;
                }
                return pc;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
