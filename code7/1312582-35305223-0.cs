    private void ColorChange_Click(object sender, RoutedEventArgs e)
    {
           var style = new Style(typeof(Button));
            style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch));
            style.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
            style.Setters.Add(new Setter(Control.FontSizeProperty, 30.0));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(1.0)));
            style.Setters.Add(new Setter(Control.BorderBrushProperty, Brushes.Black));
            style.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Orange));
            this.Resources["CalculatorButtons"] = style;
    }
