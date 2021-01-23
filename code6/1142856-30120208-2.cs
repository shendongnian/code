    var items = new List<MyObject>()
    {
        new MyObject() { Id = 1, OperationId = 1},
        new MyObject() { Id = 1, OperationId = 2},
        new MyObject() { Id = 2, OperationId = 1},
        new MyObject() { Id = 2, OperationId = 2},
        new MyObject() { Id = 3, OperationId = 2}
    };
    foreach (var obj in items)
    {
        Console.WriteLine(obj);
    }
    var result = RemoveMaxOpIdInIdGroup(items);
    Console.WriteLine("Result:");
    foreach (var obj in result)
    {
        Console.WriteLine(obj);
    }
