    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button newButton = new Button();    //Create a new button control and assign it to newButton
        newButton.Width = 35;   //Access fields like this (You can access any of the ones you access from the Xaml user interface)
        newButton.Height = 20;
        newButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        newButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
        newButton.Content = "click me!";
        grMain.Children.Add(newButton); //Add it to the grid
    }
