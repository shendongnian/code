    public int catID
        {
            get
            {
                return CategoryManager.Categories.FirstOrDefault(x => x.Name.Equals(SubCategory, StringComparison.InvariantCultureIgnoreCase)).Id;
            }
        }  
