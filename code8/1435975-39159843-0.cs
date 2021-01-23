    private List<HeisenbergProdMarketplaceCategory> SortByParentChildRelationship(List<HeisenbergProdMarketplaceCategory> heisenbergMarketplaceCategories)
    {
        List<HeisenbergProdMarketplaceCategory> sortedList = new List<HeisenbergProdMarketplaceCategory>();
        
        //we can check that a category doesn't have a parent in the same list - if it does, leave it and continue
        //eventually the list will be empty
        while(heisenbergMarketplaceCategories.Count > 0)
        {
            for (int i = heisenbergMarketplaceCategories.Count-1; i >= 0; i--)
            {
                if (heisenbergMarketplaceCategories.SingleOrDefault(p => p.ExternalCategoryID == heisenbergMarketplaceCategories[i].ExternalCategoryParentID) == null)
                {
                    sortedList.Add(heisenbergMarketplaceCategories[i]);
                    heisenbergMarketplaceCategories.RemoveAt(i);
                }
            }
        }
        
        return sortedList;
    }
