     private void theList_Tapped(object sender, TappedRoutedEventArgs e)
            {
               
                if(theList.SelectedIndex >= 0)
                button1.Content = theList.SelectedItem.ToString();
            }
