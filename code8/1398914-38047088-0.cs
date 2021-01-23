    public ITaskFilter TaskFilter { get; set; } 
    protected override void OnCreate(Bundle bundle)
    {
        TaskFilter = Mvx.Resolve<ITaskFilter>();
        TaskFilter.Initialize(this);  
    }
