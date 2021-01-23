        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Stop the timer from ticking.
            myClickWaitTimer.Stop();
            ((ICommand)DataContext).Execute("DoubleLeftClickProj");
            e.Handled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myClickWaitTimer.Start();
        }
        private static void mouseWaitTimer_Tick(object sender, EventArgs e)
        {
            myClickWaitTimer.Stop();
            // Handle Single Click Actions
            ((ICommand)context).Execute("SingleLeftClick");
        }
