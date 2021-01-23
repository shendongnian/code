    foreach (var item in itemList)
    {
        context.MyFirstEntity.Add(item);
        mySecondEntity.MyFirstEntity = item;
        context.MySecondEntity.Add(mySecondEntity);
    }
    context.SaveChanges();
