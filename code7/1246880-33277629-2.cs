    private void UpDownButton_Click(object sender, RoutedEventArgs e)
    {      
      //we can in fact use this instead data.Move(data.Count - 1, 0);
      data.Remove("Last");
      data.Insert(0, "Last");      
      CollectionViewSource.GetDefaultView(data).Refresh();
    }
    
