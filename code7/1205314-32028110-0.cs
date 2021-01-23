     private SolidColorBrush _chartColor = new SolidColorBrush(Colors.Aqua);
        public SolidColorBrush ChartColor
        {
            get
            {
                return _chartColor;
            }
            set
            {
                if (_chartColor == value)
                {
                    return;
                }
                _chartColor = value;
            }
        }
