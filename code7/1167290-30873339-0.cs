    private void dgGrid_AutogeneratingColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "name":
                var cb = new DataGridComboBoxColumn();
                // Old...
                cb.Header = "Name";
                cb.ItemsSource = new List<string>() { "Option1", "Option2", "Option3" };
                cb.SelectedItemBinding = new Binding("name");
                // NEW
                cb.EditingElementStyle = new Style(typeof(ComboBox))
                {
                    Setters =
                    {
                        new EventSetter(Selector.SelectionChangedEvent, new SelectionChangedEventHandler(OnComboBoxSelectionChanged))
                    }
                };
                e.Column = cb;
                break;
        }
    }
    private static void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // We must check that both RemovedItems and AddedItems are not empty,
        // because this event also fires when ComboBox is initialized (when entering edit mode), but then RemovedItems is empty.
        if (e.RemovedItems.Count > 0 && e.AddedItems.Count > 0)
        {
            var newlySelectedName = (string)e.AddedItems[0];
        }
    }
