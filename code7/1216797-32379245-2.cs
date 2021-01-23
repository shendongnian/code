    public async static Task DoTheWholeThing(CancellationToken cancellationToken)
    {
        var getAStuffTask = Start(async () =>
                {
                    using (var a = new A())
                    {
                        return await a.GetStuffAsync(cancellationToken);
                    }
                });
        var getBStuffTask = Start(async () =>
                {
                    using (var b = new B())
                    {
                        return await b.GetStuffAsync(cancellationToken);
                    }
                });
        var combination = CombineStuff(
            await getAStuffTask,
            await getBStuffTask);
    }
    public static Task<T> Start<T>(Func<Task<T>> asyncOperation)
    {
        return asyncOperation();
    }
