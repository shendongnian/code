    private Criteria commandCriteria;
    private ICommand CreateSectionCommand(FilterEnum filterEnum, string title = null, string searchKey = "")
    {
        commandCriteria = new Criteria
                {
                    Query = searchKey,
                    SearchFilter = filterEnum,
                    Title = title
                };
        return new RelayCommand(() =>
        {
            NavigationService.Build<SearchPageViewModel>()
                             .WithParam("criteria",commandCriteria )
                .Navigate();
        });
    }
