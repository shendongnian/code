    private List<Guid> selected;   // Keeping the ID's of selected objects
    public void PushSelected()
    {
        // Value of SelectedList can be get using
        // objectListView.SelectedObjects
        selected.Clear();
        foreach (MyObject r in SelectedList)  
            selected.Add(r.id);
    }
    public void PopSelected()
    {
        D.DeselectAll();
                
        if (selected.Count != 0)
            for (int i = 0; i < objectListView.Items.Count; i ++)
            {
                OLVListItem item = (OLVListItem)objectListView.Items[i];
                Guid g = ((MyObject)item.RowObject).id;
                if (selected.Contains(g))
                    item.Selected = true;
            }
     }
