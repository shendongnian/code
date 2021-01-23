    public IEnumerable<ListItem> SelectedItems
    {
       get 
       {
           return ACheckboxList.Items.Cast<ListItem>().Where(i => i.Selected); 
       }
    }
    public IEnumerable<Checkbox> GetAllCheckboxes()
    {
         //Find and return the checkboxes here just like you would in the page
    }
