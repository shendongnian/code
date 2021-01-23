    ListBox dragSource = null;
    private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       ListBox parent = (ListBox)sender;
       dragSource = parent;
       object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
         
       if (data != null)
       {
          DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
       }
    }
    
    #region GetDataFromListBox(ListBox,Point)
    private static object GetDataFromListBox(ListBox source, Point point)
    {
        UIElement element = source.InputHitTest(point) as UIElement;
        if (element != null)
        {
           object data = DependencyProperty.UnsetValue;
           while (data == DependencyProperty.UnsetValue)
           {
               data = source.ItemContainerGenerator.ItemFromContainer(element);
               if (data == DependencyProperty.UnsetValue)
               {
                  element = VisualTreeHelper.GetParent(element) as UIElement;
               }
               if (element == source)
               {
                  return null;
               }
            }
            if (data != DependencyProperty.UnsetValue)
            {
               return data;
            }
         }
         
         return null;
     }
               
    #endregion
        
    private void ListBox_Drop(object sender, DragEventArgs e)
    {
       ListBox parent = (ListBox)sender;
       object data = e.Data.GetData(typeof(string));
       ((IList)dragSource.ItemsSource).Remove(data);
       parent.Items.Add(data);
    }
