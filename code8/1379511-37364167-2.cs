    private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
    {
        var cbb = (ComboBox)sender;
        var projects= (Projects)cbb.SelectedItem;
        var timeLog = (TimeLog)cbb.DataContext;
        
        timeLog.SelectedProjects = projects;
    }
