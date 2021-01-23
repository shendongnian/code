    public void Remove(int id)
    {
        var selectedCategory = _category.Find(id);
        _category.Where(x => x.ParentId == id).Load();
        _category.Remove(selectedCategory);
    }
