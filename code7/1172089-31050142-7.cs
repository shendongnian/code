    protected override void InitializeMap()
    {
        _map = new WizardTransitionMap();
        _map.Add<ScreenOneViewModel, ScreenTwoViewModel>(_screenTwoFactory);
        _map.Add<ScreenTwoViewModel, ScreenOneViewModel>(_screenOneFactory);
        _map.Add<ScreenTwoViewModel, ScreenThreeViewModel>(_screenThreeFactory);
        _map.Add<ScreenThreeViewModel, ScreenTwoViewModel>(_screenTwoFactory);
        _map.Add<ScreenThreeViewModel, ScreenThreeViewModel>(null);
    }
