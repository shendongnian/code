     private void b1_click(object sender, RoutedEventArgs e)
        {
            User item = (User)((Button)sender).DataContext;
            string txt = item.PhysicalValueTxtChanged;
            
            MessageBox.Show(item.Name.ToString() + txt);
            
            
        }
