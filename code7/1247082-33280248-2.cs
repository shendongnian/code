    private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
      e.Handled = true;
    }
    private void Button_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
      MessageBox.Show("Button_PreviewMouseWheel");
    }
