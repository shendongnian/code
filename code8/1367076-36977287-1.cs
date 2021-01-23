      bool flag = true;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (flag)
                {
                    foreach (Window win in Application.Current.Windows.OfType<MainWindow>())
                    {
                        ((MainWindow)win).Hide();
                    }
                    flag = false;
                }
                else
                {
                    foreach (Window win in Application.Current.Windows.OfType<MainWindow>())
                    {
                        ((MainWindow)win).Show();
                    }
                    flag = true;
                }
            }
