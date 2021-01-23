        void Tab_OnLoaded(object sender, RoutedEventArgs e)
        {
            var tabControl = sender as TabControl;
            if (tabControl != null)
            {
                for (int i = 0; i < tabControl.Items.Count; i++)
                {
                    if (i == 1)
                        (tabControl.Items[i] as TabItem).Content = new UserControl2();//Here assign the Usercontrol that you want to set as Content
                }
                tabControl.Loaded -= Tab_OnLoaded; // Do this on first time only
            }
        }
