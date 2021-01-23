        private void UxDictionaryList_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var listbox = sender as ListBox;
            var source = e.OriginalSource as DependencyObject;
            while (source is ContentElement)
                source = LogicalTreeHelper.GetParent(source);
            while (source != null && !(source is ListBoxItem))
                source = VisualTreeHelper.GetParent(source);
            var lbi = source as ListBoxItem;
            if (lbi != null && listbox != null && _firstIndex == -1)
            {
                bool isShiftPressed = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
                //if (!isShiftPressed)
                //    _firstIndex = -1;
                //else
                //{
                    int index = listbox.ItemContainerGenerator.IndexFromContainer(lbi);
                    _firstIndex = index;
                //}
            }
        }
        private void UxDictionaryList_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
           
        }
        private void UxDictionaryList_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var listbox = sender as ListBox;
            var source = e.OriginalSource as DependencyObject;
            while (source is ContentElement)
                source = LogicalTreeHelper.GetParent(source);
       
            while (source != null && !(source is ListBoxItem))
                source = VisualTreeHelper.GetParent(source);
            var lbi = source as ListBoxItem;
            if (lbi != null && listbox != null && _firstIndex > -1)
            {
                if (!lbi.IsSelected)
                {
                    _firstIndex = -1;
                    return;
                }
                if (Keyboard.IsKeyDown(Key.LeftShift) ||
                    Keyboard.IsKeyDown(Key.RightShift))
                {
                    int index = listbox.ItemContainerGenerator.IndexFromContainer(lbi);
                    if (index > _firstIndex)
                    {
                        for (var i = _firstIndex; i <= index; i++)
                        {
                            ListBoxItem lbItem = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(i);
                            lbItem.IsSelected = true;
                        }
                    }
                    else if (index < _firstIndex)
                    {
                        for (var i = _firstIndex; i >= index; i--)
                        {
                            ListBoxItem lbItem = (ListBoxItem)listbox.ItemContainerGenerator.ContainerFromIndex(i);
                            lbItem.IsSelected = true;
                        }
                    }
                    // Reset first selected index
                    _firstIndex = -1;
                }
            }
        }
