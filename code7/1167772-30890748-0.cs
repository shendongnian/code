    //PM> Install-Package Rx-Linq
    readonly List<string> _list = new List<string> { "http://www.google.com", "https://www.gmail.com", "http://www.aripaev.ee" };
    private readonly string format = "[{0}] {1} : {2} [{3}]";
    [Category("WebClient")]
    [TestCase("sync" )]
    public void SynchronousTest(string name)
    {
        DateTime start = DateTime.Now;
        var dict = _list.ToDictionary(o => o, o => new WebClient().DownloadString(new Uri(o)));
        dict.Keys.ToList().ForEach(o => Console.WriteLine(format, DateTime.Now - start, o, dict[o].Length, name));
    }
    [Category("WebClient")]
    [TestCase("async")]
    public void AsynchronousTest(string name)
    {
        DateTime start = DateTime.Now;
        var dict = _list.ToDictionary(o => o, async o => await new WebClient().DownloadStringTaskAsync(new Uri(o)));
        dict.Keys.ToList().ForEach(o => Console.WriteLine(format, DateTime.Now - start, o, dict[o].Result.Length, name));
    }
    [Category("WebClient")]
    [TestCase("lazy")]
    public void LazyTest(string name)
    {
        var start = DateTime.Now;
        var dict = _list.ToDictionary(o => o, o => new Lazy<string>(() => new WebClient().DownloadString(new Uri(o))));
        dict.Keys.ToList().ForEach(o => Console.WriteLine(format, DateTime.Now - start, o, dict[o].Value.Length, name));
    }
