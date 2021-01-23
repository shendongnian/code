        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new Window1();
            wnd.Closed += wnd_Closed;
            wnd.Show();
        }
        void wnd_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Closed");
        }
