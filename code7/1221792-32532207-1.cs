        private void OnComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedValue = _comboBox.SelectedValue;
            this.RaiseSelectionChanged(e);
        }
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        private void RaiseSelectionChanged(SelectionChangedEventArgs args)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, args);
            }
        }
