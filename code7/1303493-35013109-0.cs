    private void button_Copy_Click(object sender, RoutedEventArgs e)
    {
        counter++;
        Label lbl = new Label();
        lbl.Content = counter.ToString();
        lbl.HorizontalAlignment = HorizontalAlignment.Center;
        lbl.VerticalAlignment = VerticalAlignment.Center;
        lbl.FontSize = 50;
        Button bt = new Button();
        bt.Content = "X";
        bt.HorizontalAlignment = HorizontalAlignment.Right;
        bt.VerticalAlignment = VerticalAlignment.Top;
        
        // add subscriber
        bt.Click += Button_Click;
        grid.Children.Add(lbl);
        grid.Children.Add(bt);
    }
    // On click event for button
    private void Button_Click(object sender, EventArgs e) 
    {
        // do whatever when button is clicked
        // this is a reference to the button that was clicked,
        // you can delete it here or do whatever with it
        Button buttonClicked = (Button)sender;
    }
