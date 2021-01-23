    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
                // E.G. To change the Fill color of Rectangle4 in StackPanel2
                var rec = FrameworkElementExtensions.TraverseCTFindShape<Shape>(myStackPanel, "myRectangle" + 2 + "-" + 4);
                rec.Fill = new SolidColorBrush(Colors.Red);
    }
