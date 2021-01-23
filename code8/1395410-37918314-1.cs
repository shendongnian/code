    public void DragOver(IDropInfo dropInfo)
    {
    	DragDrop.DefaultDropHandler.DragOver(dropInfo);
    }
    
    public void Drop(IDropInfo dropInfo)
    {
    	if (dropInfo == null || dropInfo.DragInfo == null)
    	{
    		return;
    	}
    
    	var insertIndex = dropInfo.InsertIndex != dropInfo.UnfilteredInsertIndex ? dropInfo.UnfilteredInsertIndex : dropInfo.InsertIndex;
    	var destinationList = dropInfo.TargetCollection.TryGetList();
    	var data = ExtractData(dropInfo.Data);
    
    	// default to copy but not if source equals target
    	var copyData = (!Equals(dropInfo.DragInfo.SourceCollection, dropInfo.TargetCollection)) 
    				   && !(dropInfo.DragInfo.SourceItem is HeaderedContentControl)
    				   && !(dropInfo.DragInfo.SourceItem is HeaderedItemsControl)
    				   && !(dropInfo.DragInfo.SourceItem is ListBoxItem);
    	if (!copyData)
    	{
    		var sourceList = dropInfo.DragInfo.SourceCollection.TryGetList();
    
    		foreach (var o in data)
    		{
    			var index = sourceList.IndexOf(o);
    
    			if (index != -1)
    			{
    				sourceList.RemoveAt(index);
    				if (Equals(sourceList, destinationList) && index < insertIndex)
    				{
    					--insertIndex;
    				}
    			}
    		}
    	}
    
    	var tabControl = dropInfo.VisualTarget as TabControl;
    
    	// clone data but not if source equals target
    	var cloneData = !Equals(dropInfo.DragInfo.SourceCollection, dropInfo.TargetCollection); 
    	foreach (var o in data)
    	{
    		var obj2Insert = o;
    		if (cloneData)
    		{
    			var cloneable = o as ICloneable;
    			if (cloneable != null)
    			{
    				obj2Insert = cloneable.Clone();
    			}
    		}
    
    		destinationList.Insert(insertIndex++, obj2Insert);
    
    		if (tabControl != null)
    		{
    			var container = tabControl.ItemContainerGenerator.ContainerFromItem(obj2Insert) as TabItem;
    			if (container != null)
    			{
    				container.ApplyTemplate();
    			}
    
    			tabControl.SetSelectedItem(obj2Insert);
    		}
    	}
    }
    
    public static IEnumerable ExtractData(object data)
    {
    	if (data is IEnumerable && !(data is string))
    	{
    		return (IEnumerable)data;
    	}
    	else
    	{
    		return Enumerable.Repeat(data, 1);
    	}
    }
