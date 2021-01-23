     private void OnMouseTouchDown(object sender, InputEventArgs e)
            {
                var item = sender as FrameworkElement;
                if (item == null) return;
    
                var draggedItem = item;
                var points = Convert.ToInt32(draggedItem.Tag);
                CreateDragDropWindow(draggedItem);
                System.Windows.DragDrop.AddQueryContinueDragHandler(draggedItem, DragContrinueHandler);
                System.Windows.DragDrop.DoDragDrop(draggedItem, points, DragDropEffects.Move);
            }
