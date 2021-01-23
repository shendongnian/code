    var stackPanel = new StackPanel() { Orientation = System.Windows.Controls.Orientation.Horizontal };
    var image1 = new Image() { Source = image1Path };
    var image2 = new Image() { Source = image2Path };
    var textBlock = new TextBlock() { Text = itemHeader };
    stackPanel.Children.Add(image1);
    stackPanel.Children.Add(image2);
    stackPanel.Children.Add(textBlock);
     
    var treeViewItem = new RadTreeViewItem()
    {
        Header = stackPanel,
    };
