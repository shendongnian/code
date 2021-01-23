    public SearchFilterUserControl()
    {
        InitializeComponent();
        this.DataContext = new SearchFilterViewModel();
    }
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        GetTemplateChild("LayoutRoot").DataContext = new SearchFilterViewModel();
    }
	
