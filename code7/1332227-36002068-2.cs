    PlanningStatsViewModel _planningStats;
        public PlanningStatsViewModel PlanningStats
        {
            get { return _planningStats; }
            set { _planningStats = value; RaisePropertyChanged(() => PlanningStats); }
        }
        ObservableCollection<PlanningGWViewModel> _planningGW;
        public ObservableCollection<PlanningGWViewModel> PlanningGW
        {
            get { return _planningGW; }
            set { _planningGW = value; RaisePropertyChanged(() => PlanningGW); }
        }
    public void BuildInterface()
        {
            PlanningStats = new PlanningStatsViewModel(_dataService, _loadingService, _messenger, _messageService);
            PlanningGW = new ObservableCollection<PlanningGWViewModel>();
            var nonPlayedGameweeks = Service.GetCacheNonPlayedGameweeksAsync().Result;
            var query = nonPlayedGameweeks.ToList();
            if (query.Any())
            {
                CurrentGW = query.Min(f => f.GameWeek);
                var grouped = query.ToList().GroupBy(f => f.GameWeek, f => f, (key, g) => new { Gameweek = key, Fixtures = g.ToList() });
                foreach (var grp in grouped.Take(SettingsPreferences.SelectedPlanUpcoming))
                    if (grp.Gameweek <= BusinessConstants.NumGamesSeason)
                        PlanningGW.Add(new PlanningGWViewModel(grp.Gameweek, _dataService, _loadingService, _messenger, _messageService));
            }
        }
