    public void AddItems(string items, IRepository repository)
    {
        var allTags = repository.GetAllQueryAble();
        string[] tag = items.Split(',');
        foreach (var item in tag)
        {
            if (!allTags.Any(e => e.Name.Contains(item)))
            {
                repository.Add
                (
                    item,
                    DateTime.Now,
                    DateTime.Now,
                    false
                );
            }
        }
    }
