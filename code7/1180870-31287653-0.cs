    public ObservableCollection<Image> FindVisualReferences { get; set; }
    private void FindImage()
    {
         string SearchTerm = this.SearchBox;
         var dbFunctions = new DatabaseFunctions();
         FindVisualReferences.Clear();
         FindVisualReferences.AddRange(dbFunctions.FindVisualReferences(SearchTerm));
    }
    
