    List<IEntity> list1 = new List<IEntity>() { new Entity() { Id = 1 }, new Entity() { Id = 10 } };
    List<IEntity> list2 = new List<IEntity>() { new Entity() { Id = 1 }, new Entity() { Id = 5 } };
    List<IEntity> result = Compare(list1, list2).ToList();
    
    foreach (IEntity item in result)
    {
        Console.WriteLine(item.Id);
    }
