    private void UpDownButton_Click(object sender, RoutedEventArgs e)
    {
      //before changing any item at index 0 such as by inserting 
      //some new one or even use the method Move(... , 0),      
      //We need to clear all the realized item containers
      var cg = _stuff.ItemContainerGenerator as IItemContainerGenerator;
      cg.RemoveAll();
      //now just proceed the code
      //we can in fact use this instead data.Move(data.Count - 1, 0);
      data.Remove("Last");
      data.Insert(0, "Last");      
    }
    
