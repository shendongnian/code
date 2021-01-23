    for (int b = 1; b < 7; b++)
    {
        for (int c = 0; c < 7; c++)
        {
            date = new TextBlock();
            date .Margin = new Thickness(1);
            date .TextAlignment = TextAlignment.Center;
            date .FontSize = 15;
            date .HorizontalAlignment = HorizontalAlignment.Stretch;
            date .VerticalAlignment = VerticalAlignment.Center;
            date .Tapped += new TappedEventHandler(
                                new Action<object, TappedRoutedEventArgs>((o, e) =>
                                    {
                                        var x = a;  // You can use the current value of "a" here
                                        // Do stuff with a, b and c
                                        // Do other stuff
                                    }));
            string middle= TIME.days[a].ToString();
            if (middle== "0") { middle= ""; }
            date.Text = middle;
            a++;
            Grid.SetRow(date , b);
            Grid.SetColumn(date , c);
            gridDatum.Children.Add(date );
        }    
    }
