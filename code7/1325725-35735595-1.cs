    public int SelectedCategoryIndex {get; set;}
    public List<Category> Categories {get; private set;}
    public List<int> CategoryItems
    {
      get
      {
        return this.Categories[SelectedCategoryIndex].CategoryItems;
      }
    }
