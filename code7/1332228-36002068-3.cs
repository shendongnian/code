    ObservableCollection<PlanningGWItemsViewModelWrapper> _planningGWItems;
        public ObservableCollection<PlanningGWItemsViewModelWrapper> PlanningGWItems
        {
            get { return _planningGWItems; }
            set { _planningGWItems = value; RaisePropertyChanged(() => PlanningGWItems); }
        }
    public async Task RebuildLists(bool displayLoading)
        {
            IsLoading = displayLoading;
            Standings = await Service.GetCacheStandingsAsync().ConfigureAwait(false);
            var nonPlayedGameweeks = await Service.GetCacheNonPlayedGameweeksAsync().ConfigureAwait(false);
            PlanningGWItems = await BuildList(Standings, nonPlayedGameweeks.Where(f => f.GameWeek == _gameweek).OrderBy(f => f.Date).ToList()).ConfigureAwait(false);
            IsLoading = false;
        }
