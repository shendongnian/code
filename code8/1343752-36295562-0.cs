    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null)
            {
                return;
            }
            var item = cb.DataContext;
            this.ExportersList.SelectedItem = item;
            this.ExportersList.SelectedValue = this.ExportersList.SelectedItem.GetType().GetProperty("Name").GetValue(this.ExportersList.SelectedItem, null);
        }
