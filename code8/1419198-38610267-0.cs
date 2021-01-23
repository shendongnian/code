    static void Main()
    {
        var selectMany = Enumerable.Range(1, 100)
                            .ToObservable()
                            .Select(i => Observable.Defer(() => Observable.Return(new LargeObject(i)))
                                .SelectMany(o => Observable.FromAsync(() => DoSomethingAsync(o)))
                            ).Merge(4);
        selectMany
            .Subscribe(r => Console.WriteLine(r));
        Console.ReadLine();
    }
    private static async Task<int> DoSomethingAsync(LargeObject lo)
    {
        await Task.Delay(10000);
        return lo.Id;
    }
    internal class LargeObject
    {
        public int Id { get; }
        public LargeObject(int id)
        {
            this.Id = id;
            Console.WriteLine(id + "!");
        }
        public byte[] Data { get; } = new byte[10000000];
    }
