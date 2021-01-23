            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Window1 win = new Window1();
                win.Loaded += win_Loaded;
                win.Closed += win_Closed;
                win.ShowDialog();
            }
    
            void win_Closed(object sender, EventArgs e)
            {
                this.but.Visibility = Visibility.Visible;
            }
    
            void win_Loaded(object sender, RoutedEventArgs e)
            {
                this.but.Visibility = Visibility.Hidden;
            }
