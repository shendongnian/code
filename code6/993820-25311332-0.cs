    IEnumerable<MyModel> GetGroupedModels(IEnumerable<MyModel> myModels)
    {
        foreach (var group in myModels.GroupBy(x => new { x.Date, x.TransID }))
        {
            foreach (var item in group)
                yield return item;
            if (group.Count() > 1)
                yield return new MyModel { Quantity = group.Sum(x => x.Quantity), Price = group.Sum(x => x.Price) };
        }
    }
