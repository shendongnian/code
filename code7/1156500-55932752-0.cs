    private void Window_Main_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
        {
            this.DragMove();
            e.Handled = true;
        }
    }
