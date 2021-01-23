    private void FindVisibleItems(ListBox listbox) 
        { 
            var listboxRectangle = new Rect(new Point(0, 0), listbox.RenderSize); 
            for (int index = 0; index < listbox.Items.Count; index++) 
            { 
                double visiblePercent = 0; 
 
                ListBoxItem item = listbox.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem; 
                if (item != null) 
                { 
                    var itemTransform = item.TransformToVisual(listbox); 
                    var itemRectangle = itemTransform.TransformBounds(new Rect(new Point(0, 0), item.RenderSize)); 
                    itemRectangle.Intersect(listboxRectangle); 
 
                    if (!itemRectangle.IsEmpty) 
                    { 
                        visiblePercent = itemRectangle.Height / item.RenderSize.Height * 100; 
                    } 
                } 
 
                System.Diagnostics.Debug.WriteLine(string.Format("Item {0}: {1}% visible", index, Math.Round(visiblePercent))); 
            } 
        }
