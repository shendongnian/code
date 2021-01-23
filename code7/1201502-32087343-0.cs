        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //var numericBoxControl = (NumericTextBox)sender;
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); Text = value.ToString("###,###,###"); }
        }
