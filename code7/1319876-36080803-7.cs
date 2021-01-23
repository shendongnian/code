    void s_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
         if (sender is ListBoxItem)
          {
             ListBoxItem draggedItem = sender as ListBoxItem;
             DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
             draggedItem.IsSelected = true;
          }
    }
