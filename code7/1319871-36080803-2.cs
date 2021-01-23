    void s_PreviewMouseMoveEvent(object sender, MouseButtonEventArgs e)
        {
             if (sender is ListBoxItem && e.LeftButton == MouseButtonState.Pressed)
              {
                 ListBoxItem draggedItem = sender as ListBoxItem;
                 DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                 draggedItem.IsSelected = true;
              }
            
        }
