    return JsonConvert.SerializeObject(
        data.GroupBy(x=> new {x.Name, x.Amount})
            .Where(gp => gp.Count() > 1)
            .Select((gp, idx) =>
                    new Group
                    {
                        GroupData = gp.Select(el => new GroupItem
                        {
                            Name = el.Name,
                            Amount = el.Amount,
                            GroupId = idx
                        })
                    }));
