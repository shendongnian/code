        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2");
        }
        private void Button1_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            button1_Click(sender,e);
        }
        private void Button2_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            button2_Click(sender,e);
        }
        private void Button1_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
        private void Button2_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
