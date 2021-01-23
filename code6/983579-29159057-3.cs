    private IHudService hudService;
    public IHudService HudService
    {
        get
        {
            if(hudService == null)
            {
                hudService = DependencyService.Get<IHudService>();
            }
            return this.hudService;
        }
    }
        
    private async Task Setup()
    {
        this.HudService.Show("Long operation occurring", MaskType.Black);
        
        await Operation();
            
        this.HudService.Dismiss();
    }
