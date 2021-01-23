     public List<ProductListItem> Allergens 
     { 
        get { return this.ProductListItems.Where(i => i.ListType.Name=="Allergens").ToList=();}
     }
   
