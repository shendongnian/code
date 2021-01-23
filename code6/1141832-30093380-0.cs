    void ShowDialog_Click_1(object sender, RoutedEventArgs e) {
        DXDialog dlg = new DXDialog("Information", DialogButtons.Ok, true);
        dlg.Content = new UserControlWithDXGrid();
        dlg.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        dlg.Owner = this;
        dlg.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
        dlg.ShowDialog();
    }
