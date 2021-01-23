    private void SomeOperation(ICollection<Category> list)
    {
        foreach (Category category in list)
        {
            //Do something
            SomeOperation(category.SubCategories);
        }
    }
