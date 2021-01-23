     public CustomComboBox()
        {
            CustomItems = new ObservableCollection<ComboBoxItem>();
            CustomItems.Add(new ComboBoxItem() { Content = "4" });
            CustomItems.Add(new ComboBoxItem() { Content = "5" });
            DataContext = this;
        }
