    private readonly IDataProvider dataProvider;
    public TagsController(IDataProvider dataProvider)
    {
        this.dataProvider = dataProvider;
    }
    public IEnumerable<Tags> Get()
    {
        return this.dataProvider.GetTags();
    }
    public Tags Get(int id)
    {
        var Tags = this.dataProvider.GetTags().FirstOrDefault(c => c.Id == id);
        if (Tags == null)
        {
            throw new HttpResponseException(
                System.Net.HttpStatusCode.NotFound);
        }
        return Tags;
    }
