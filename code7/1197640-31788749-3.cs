    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (this.OwnedWindows.Count > 0)
        {
            MessageBox.Show("Child windows exists, you have to close'em first");
            e.Cancel = true;
        }
    }
