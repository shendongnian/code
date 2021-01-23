    private void tabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count != 0)
        {
            var myViewModel = (MyViewModel)DataContext;
            var text = myViewModel.TextInFirstTab;
        }
    }
