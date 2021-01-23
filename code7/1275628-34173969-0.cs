        private void OpenOSK()
        {
            try
            {
                Process.Start("TabTip.exe");
            }
            catch
            {
            }
        }
        private void _textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            OpenOSK();
        }
