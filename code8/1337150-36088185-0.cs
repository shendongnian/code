    public async ActionResult Index()
    {
        var idlist = new List<string>() { "123", "massive list of strings....", "789" };
        IEnumerable<XElement> list = await ProcessList(idlist);
        //sort the list as it will be completely out of order
        return View(xdoc);
    }
    public async Task<IEnumerable<XElement>> ProcessList(IEnumerable<string> idlist)
    {
        IEnumerable<XElement>[] processList = await Task.WhenAll(idlist.Select(FooBar));
        return processList.Select(x => x.ToList()).SelectMany(x => x);
    }
    private async Task<IEnumerable<XElement>> FooBar(string id)
    {
        Task<IEnumerable<XElement>> foo = Foo(id);
        Task<IEnumerable<XElement>> bar = Bar(id);
        return ((await bar).Concat(await foo));
    }
    private async Task<IEnumerable<XElement>> Bar(string id)
    {
        var localListOfElements = new List<XElement>();
        var keepGoingFoo = true;
        while (keepGoingFoo)
        {
            var response = await ServiceCallAsync(); //make sure you use the async version
            localListOfElements.Add(new XElement("r"));
            keepGoingFoo = response.moreRecordsExist;
        }
        return localListOfElements;
    }
    private async Task<IEnumerable<XElement>> Foo(string id)
    {
        var localListOfElements = new List<XElement>();
        var keepGoingFoo = true;
        while (keepGoingFoo)
        {
            var response = await ServiceCallAsync(); //make sure you use the async version
            localListOfElements.Add(new XElement("r"));
            keepGoingFoo = response.moreRecordsExist;
        }
        return localListOfElements;
    }
    private async Task<Response> ServiceCallAsync()
    {
        await Task.Delay(1000);//simulation
        return new Response();
    }
