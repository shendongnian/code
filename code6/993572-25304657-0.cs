    private void OnBasicEntryCompleted(object sender, BasicEntryEventArgs e)
    {
        if (e.Result.Any())
        {
            e.TargetComboBox.ItemsSource = e.Result.ToList();
            e.TargetComboBox.DisplayMemberPath = "Description";
            e.TargetComboBox.SelectedItem = "ID";
        }
        else
        {
            e.TargetComboBox.ItemsSource = null;
        }
        var proxy = (Proxy)sender;
        proxy.GetBasicEntryCompleted -= OnBasicEntryCompleted;
    }
    public void Sniper(string sourceTableName, ComboBox targetComboBox)
    {
        proxy.GetBasicEntryCompleted += OnBasicEntryCompleted;
        proxy.GetBasicEntryAsync(sourceTableName, targetComboBox);
    }
