    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var close = MessageBox.Show("Do you want to close the programm?", "", MessageBoxButton.YesNo);
            if (close == MessageBoxResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
