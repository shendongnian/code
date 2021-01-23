    private void Hyperlink_RequestNavigate(object sender,   System.Windows.Navigation.RequestNavigateEventArgs e)
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri+textBox.Text));
                e.Handled = true;
            }
            
