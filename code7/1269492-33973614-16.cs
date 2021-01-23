        private void UpdateSelectedWeekdays()
        {
            if (!this.updating)
            {
                this.updating = true;
                var selectedWeekdays = this.checkboxes.Where(x => x.IsChecked.HasValue && x.IsChecked.Value).Select(x => x.Tag).Cast<Weekday>();
                                
                SetCurrentValue(DropDownDayPicker.SelectedWeekdaysProperty, new ObservableCollection<Weekday>(selectedWeekdays));
                BindingExpression binding = this.GetBindingExpression(DropDownDayPicker.SelectedWeekdaysProperty);
                if (binding != null)
                {
                    binding.UpdateSource();
                }
                this.UpdateSummary();
                this.updating = false;
            }
        }
