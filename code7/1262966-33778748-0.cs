    <ComboBox SelectionChanged="Selector_OnSelectionChanged">
        <ComboBoxItem Tag="some value">Text</ComboBoxItem>
        <ComboBoxItem Tag="some value2">Text2</ComboBoxItem>
        <ComboBoxItem Tag="some value3">Text3</ComboBoxItem>
    </ComboBox>
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = sender as ComboBox;
            if (cb == null)
            {
                return;
            }
            
            var selectedItem = cb.SelectedValue as ComboBoxItem;
            if (selectedItem == null)
            {
                return;
            }
            var tag = selectedItem.Tag;
            Debug.WriteLine(tag);  
        }
