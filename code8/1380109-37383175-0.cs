    private void ComboboxItem_Chosen(object sender, RoutedEventArgs e)
     { 
    if (combobox.SelectedText != null)
     { txttnumber.Visibility =Visibility.Visible;
     } 
    else 
    { combobox.Visibility =Visibility.Collapsed; 
    }
     }
