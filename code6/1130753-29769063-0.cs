    private CatlougeData LastDeletedItem { get; set;}
    
    public void OnDeleteMenu (object sender, EventArgs e) 
    {
        var SelectedMenu = ((MenuItem)sender);
        LastDeletedItem = (CatlougeData)SelectedMenu.CommandParameter;
        items.Remove ((CatlougeData)SelectedMenu.CommandParameter);
     }
