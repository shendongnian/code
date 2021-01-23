    // Assuming this is your constructor
    public ViewModel()
    {
    	this.FooViewSource.Source = this.fooCollection;
    }
    
    private readonly List<FooDto> fooCollection = new List<FooDto>();
    
    private readonly CollectionViewSource fooViewSource;
    public CollectionViewSource FooViewSource
    {
        get { return this.fooViewSource; }
    }
    
    private void Foo()
    {
        foreach (var element in collection)
        {
            this.fooCollection.Add(new FooDto()
            {
                X = element.Foo1,
                Y = element.Foo2,
                Z = element.Foo3
            });
        }
        this.FooViewSource.View.Refresh();
    }
