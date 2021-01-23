    private Action _removeSubs;
    public Sniper(string sourceTableName, ComboBox targetComboBox)
        {
            proxy.GetBasicEntryAsync(sourceTableName);
            Action <object, EventArgs> _handler = (sender, e) =>
            {
                if (e.Result.Any())
                {
                    targetComboBox.ItemsSource = e.Result.ToList();
                    targetComboBox.DisplayMemberPath = "Description";
                    targetComboBox.SelectedItem = "ID";
                }
                else
                {
                    targetComboBox.ItemsSource = null;
                }
            };
            proxy.GetBasicEntryCompleted += handler;
            _removeSubs = () => proxy.GetBasicEntryCompleted -= handler;
        }
