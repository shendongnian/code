    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = this.comboBox.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
            {
                StackPanel stackPanel = comboBoxItem.Content as StackPanel;
                if(stackPanel != null && stackPanel.Children[0] is Rectangle)
                {
                    var fill = (stackPanel.Children[0] as Rectangle).Fill;
                }
            }
        }
