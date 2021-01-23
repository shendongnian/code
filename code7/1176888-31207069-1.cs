    private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ClickedSomething = ((TestSL.TT)(((System.Windows.Controls.ContentPresenter)(VisualTreeHelper.GetParent(sender as Button))).DataContext)).Something;
            SilverlightMessageBoxLibrary.CustomMessage cm = new SilverlightMessageBoxLibrary.CustomMessage("You clicked on " + ClickedSomething, SilverlightMessageBoxLibrary.CustomMessage.MessageType.Error);
            cm.Show();
        }
