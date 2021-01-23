    var processors = DependencyResolver.Current.GetServices<IProcessor>();
    var group = processors.GroupBy(x => x.Order()).OrderBy(x => x.Key);
    var model = new Model();
    foreach (var item in group)
    {
        var tasks = item.Select(x => Task.Factory.StartNew(() => x.Process(model))).ToArray();
        Task.WaitAll(tasks);
    }
