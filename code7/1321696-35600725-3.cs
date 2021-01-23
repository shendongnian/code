    private void SomeMethod()
    {
        ComboBoxItem item = new ComboBoxItem();
        for (int start = 0; start < 10; start++)
        {
           if (item == null)
              item = new ComboBoxItem();
           item.Background= Brushes.Green;                
           item.Content = start.ToString();
           comboBox.Items.Add(item);
           item = null;
        }            
    }
