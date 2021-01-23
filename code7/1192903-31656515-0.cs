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
            date .Tag = new int[] { a, b, c };
            date .Tapped += date_Taped;
            string middle= TIME.days[a].ToString();
            if (middle== "0") { middle= ""; }
            date.Text = middle;
            a++;
            Grid.SetRow(date , b);
            Grid.SetColumn(date , c);
            gridDatum.Children.Add(date );
        }    
    }
    private void date_Taped(object sender, TappedRoutedEventArgs e)
    {
        var textBlock = sender as TextBlock;
        var a = (textBlock.Tag as int[])[0];
        var b = (textBlock.Tag as int[])[1];
        var c = (textBlock.Tag as int[])[2];
        // Do stuff with a, b and c
        // Do other stuff
    }
