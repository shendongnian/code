    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                ListBoxItem item = lbMenu.SelectedItem as ListBoxItem;
                if(item != null)
                {
                    switch (item.Name)
                    {
                        case "login":
                            MessageBox.Show("login");
                            break;
                        case "about":
                            MessageBox.Show("about");
                            break;
                    }
    
                }
            }
