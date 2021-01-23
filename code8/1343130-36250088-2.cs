    foreach (var item in OrderList(list))
        Console.WriteLine(item.ToString());
    (...)
    private static List<MyClass> OrderList(List<MyClass> list)
    {
        List<MyClass> orderedList = new List<MyClass>(list.Count());
        foreach (var item in list.Where(x => !x.ParentId.HasValue).OrderBy(x => x.Id))
            AddItem(item, list, orderedList);
        return orderedList;
    }
    private static void AddItem(MyClass item, List<MyClass> list, List<MyClass> orderedList)
    {
        orderedList.Add(item);
        foreach (var subitem in list.Where(x => x.ParentId == item.Id).OrderBy(x => x.Id))
            AddItem(subitem, list, orderedList);
    }
