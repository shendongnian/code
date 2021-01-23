    private void Content_Click(object sender, RoutedEventArgs e)
     {
           Style style = new Style{ TargetType = typeof(Button)};
           style.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.Blue));
           this.Resources["Style1"] = style;
     }
