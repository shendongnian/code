    private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                Button oButton = new Button();
                oButton.Name = "btnMessage";
                oButton.Content = "Message Show";
                oButton.Height = 50;
                oButton.Width = 50;
                oButton.Click += new RoutedEventHandler(oButton_Click);
                //root is a stack panel
                root.Children.Insert(root.Children.Count, oButton);
                DockPanel.SetDock(oButton, Dock.Top);
    
            }
    
            void oButton_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Hello World !");
            }
