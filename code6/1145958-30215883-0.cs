    public static readonly DependencyProperty FillColourProperty = DependencyProperty.Register
            ("FillColour", typeof(string), typeof(RectangleFillTest), new PropertyMetadata(string.Empty, ValueChanged));
        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RectangleFillTest;
            var fillBrush = new SolidColorBrush();
            if (control.FillColour == "red")
                fillBrush = new SolidColorBrush(Colors.Red);
            else
                fillBrush = new SolidColorBrush(Colors.Green);
            control.rect.Fill = fillBrush;
        }
        public string FillColour
        {
            get
            {
                return (string)GetValue(FillColourProperty);
            }
            set
            {
                SetValue(FillColourProperty, value);
                
            }
        }
