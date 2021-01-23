        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            richTextBox1.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(HyperLink_RequestNavigate));
        }
        void HyperLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
