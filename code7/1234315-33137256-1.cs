    private Point dragStartPoint;
    // Bindable list of pages (binding logic omitted-out of scope of this post)
    private static ObservableCollection<DocPage> pages = new ObservableCollection<DocPage>();
    
    // Find parent of 'child' of type 'T'
    public static T FindParent<T>(DependencyObject child) where T : DependencyObject
    {
        do
        {
            if (child is T)
                return (T)child;
            child = VisualTreeHelper.GetParent(child);
        } while (child != null);
        return null;
    }
    
    private void lbx_Pages_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        dragStartPoint = e.GetPosition(null);
    }
    
    private void lbx_Pages_PreviewMouseMove(object sender, MouseEventArgs e)
    {
            
        ListBoxItem item = null;
        DataObject dragData;
        ListBox listBox;
        DocPage page;
        // Is LMB down and did the mouse move far enough to register a drag?
        if (e.LeftButton == MouseButtonState.Pressed &&
            (Math.Abs(dragStartPoint.X - e.GetPosition(null).X) > SystemParameters.MinimumHorizontalDragDistance ||
            Math.Abs(dragStartPoint.Y - e.GetPosition(null).Y) > SystemParameters.MinimumVerticalDragDistance))
        {
            // Get the ListBoxItem object from the object being dragged
            item = FindParent<ListBoxItem>((DependencyObject)e.OriginalSource);
            if (null != item)
            {
                listBox = sender as ListBox;
                page = (DocPage)listBox.ItemContainerGenerator.ItemFromContainer(item);
                dragData = new DataObject("pages", page);
                DragDrop.DoDragDrop(item, dragData, DragDropEffects.Move);
            }
        }
    }
    
    private void lbx_Pages_PagesDrop(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent("pages"))
            return;
        DocPage draggedItem = e.Data.GetData("pages") as DocPage;
        // Hit-test needed for rearranging items in the same ListBox
        HitTestResult hit = VisualTreeHelper.HitTest((ListBox)sender, e.GetPosition((ListBox)sender));
        DocPage target = (DocPage)FindParent<ListBoxItem>(hit.VisualHit).DataContext;
        int removeIdx = lbx_Pages.Items.IndexOf(draggedItem);
        int targetIdx = lbx_Pages.Items.IndexOf(target);
        if(removeIdx < targetIdx)
        {
            pages.Insert(targetIdx + 1, draggedItem);
            pages.RemoveAt(removeIdx);
        }
        else
        {
            removeIdx++;
            if(pages.Count+1 > removeIdx)
            {
                pages.Insert(targetIdx, draggedItem);
                pages.RemoveAt(removeIdx);
            }
        }
    }
    private void lbx_Pages_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent("pages") || sender == e.Source)
            e.Effects = DragDropEffects.None;
    }
