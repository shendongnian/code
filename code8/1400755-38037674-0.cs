    var web = StaticClass.Context.Web;
    var list = web.GetList('Lists/example');
    var item = list.GetItemById(1);
    item["Title"] = "Test";
    var result = repository.GetItemsAndExecute();
    //or some other thread calls StaticClass.Context.ExecuteQuery();
    item.Update();
    StaticClass.Context.ExecuteQuery();
