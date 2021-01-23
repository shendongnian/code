    void Execute(IEnumerable<BaseObject> list)
    {
        foreach (var item in list)
        {
            var worker = DIContainer.Instance.GetObject<IBaseObjectWorker>(item.GetType().ToString());
            worker?.DoWork(item);
        }
    }
