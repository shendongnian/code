    Line objLine;
    private void button_Click(object sender, RoutedEventArgs e)
    {
        objLine = new Line(); //point input
        ...
        hello.Children.Add(objLine);
    }
    private void removeButton_Click(object sender, RoutedEventArgs e)
    {
        if(objLine != null) {
           hello.Children.Remove(objLine);
        }
    }
