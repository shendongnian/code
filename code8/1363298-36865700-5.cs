    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.MessageBox mbox = new Xceed.Wpf.Toolkit.MessageBox();
            mbox.OkButtonStyle = (Style)Resources["ButtonStyle1"];
            mbox.OkButtonContent = "Click Me !";
            mbox.Caption = "My custom caption";
            mbox.Text = "My custom message";
            mbox.ShowDialog();
        }
