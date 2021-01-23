    var cats = new List<Cat>();
    var dog = new Dog();
    var loadDataTasks = new Task[]
    {
        Task.Run(async () => cats = await LoadCatsAsync()),
        Task.Run(async () => dog = await LoadDogAsync())
    };
    try
    {
        await Task.WhenAll(loadDataTasks);
    }
    catch (Exception ex)
    {
        // handle exception
    }
        
