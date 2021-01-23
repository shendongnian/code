    private void removebtn_Click(object sender, RoutedEventArgs e)
    {
         object[] itemsToRemove = new object[ListBoxPlayList.SelectedItems.Count];
         ListBoxPlayList.SelectedItems.CopyTo(itemsToRemove, 0);
         foreach (object item in itemsToRemove)
         {
             string filePath;
	         fileDictionary.TryGetValue(item, out filePath);
             if (mediaelement.Source != new Uri(filePath))  //MediaPlayer source
             {  //you forgot the parenthesis for the if condition.
                ListBoxPlayList.Items.Remove(item);//remove from list
                fileDictionary.Remove(item);//remove from dictionary
             }
         }
    }
