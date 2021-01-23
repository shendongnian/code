    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var my_canvas = new Canvas();
        var textbox = new TextBox();
        my_canvas.Children.Add(textbox);
        flipView.Items.Insert(flipView.SelectedIndex + 1, my_canvas);
        flipView.Items.RemoveAt(flipView.SelectedIndex);              
    }
  
