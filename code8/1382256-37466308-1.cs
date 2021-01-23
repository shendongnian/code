    private void Grid_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
    {
        string tempStatus = ((SessionViewModel) DataContext).StatusIconPath;
        string tempResult = ((SessionViewModel) DataContext).ResultIconPath;
        StatusImage.Source = new BitmapImage(new Uri(@tempStatus, UriKind.Relative));
        ResultImage.Source = new BitmapImage(new Uri(@tempResult, UriKind.Relative));
    }
