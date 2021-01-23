    private void changeSzie_Click(object sender, RoutedEventArgs e)
    {
        var dynamicStyle = new Windows.UI.Xaml.Style();
        var targetType = typeof(Windows.UI.Xaml.Controls.TextBlock);
        dynamicStyle.TargetType = targetType;
        dynamicStyle.Setters.Add(new Setter(Windows.UI.Xaml.Controls.TextBlock.FontSizeProperty, int.Parse(textbox.Text)));
        if (mainGrid.Resources.Keys.Contains(targetType))
        {
            mainGrid.Resources.Remove(targetType);
        }
        mainGrid.Resources.Add(targetType, dynamicStyle);
    }
