    viewSource.View.GroupDescriptions.CollectionChanged += View_CollectionChanged;
	
	async void View_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        // later ...
        await Task.Delay(100);
        RemoveMargins();
    }
    private void RemoveMargins()
    {
	    // For FindAllVisualDescendants() function, see my answer to that question : 
        // http://stackoverflow.com/questions/32755837/find-textbox-in-datagrid-wpf/32756372#32756372
        var allItemsPresenter = datagridPersons.FindAllVisualDescendants()
            .OfType<ItemsPresenter>()
            .Where(elt => elt.Name == "ItemsPresenter")
            .Where(elt => elt.Margin == new Thickness(5, 0, 0, 0));
        foreach (var itemsPresenter in allItemsPresenter)
        {
            itemsPresenter.Margin = new Thickness(0, 0, 0, 0);
        }
    }
	
