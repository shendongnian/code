    private void tabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count != 0)
        {
            var tabItem = (TabItem)e.RemovedItems[0];
            var content = (Grid)tabItem.Content;
            var textBox = content.Children.OfType<TextBox>().First();
            var text = textBox.Text;
        }
    }
