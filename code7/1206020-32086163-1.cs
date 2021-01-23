    //Used to save the objects of all grids
    List<GridGroupingControl> grids = new List<GridGroupingControl>();
    
    //add the grid to the list
    grids.Add(GridGroupingControl);
    
    void RecordFilters_Changed(object sender, Syncfusion.Collections.ListPropertyChangedEventArgs e)
    {
        Syncfusion.Grouping.RecordFilterDescriptorCollection filters = sender as RecordFilterDescriptorCollection;
        foreach (GridGroupingControl grid in grids)
        {
            foreach(RecordFilterDescriptor filter in filters)
            {
                //To avoid the repeated objects from the list
                if (grid.TableDescriptor.RecordFilters.Contains(filter))
                    continue;
                grid.TableDescriptor.RecordFilters.Add(filter);
            }
        }
    }
