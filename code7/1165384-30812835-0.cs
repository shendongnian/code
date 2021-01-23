     Style style = new Style(typeof(Control));
     style.Setters.Add(new Setter(Control.BackgroundProperty, new  SolidColorBrush(Colors.Red)));
     style.Setters.Add(new Setter(Control.HeightProperty, 5));
     style.Setters.Add(new Setter(Control.WidthProperty, 5));
     series.DataPointStyle = style;
