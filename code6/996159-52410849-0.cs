    private List<string> _practiceItems;
    public List<string> PracticeItems
    {
        get => _practiceItems;
        set => SetProperty(ref _practiceItems, value);
    }
    public override async Task Initialize()
    {
        await base.Initialize();        
        PracticeItems = await _homeService.GetPracticeList(this);
    }
