    public class ViewModel : PropertyChangedBase
    {
        private readonly ScoreBoard board;
        public ObservableCollection<string> Columns { get; private set; }
        public ObservableCollection<Game> Games { get; private set; } 
        public ObservableCollection<RowViewModel> Rows { get; private set; } 
        public ViewModel(ScoreBoard board)
        {
            this.board = board;
            this.board.Changed += OnBoardChanged;
            UpdateColumns(this.board.Games.Select(x => x.Name));
            UpdateRows(this.board.Players, this.board.Games);
            this.board.StartUpdate();
        }
        private void OnBoardChanged(object sender, ScoreBoardChangeEventArgs e)
        {
            var games = 
                this.board.Games
                          .Except(e.RemovedGames)
                          .Concat(e.AddedGames)
                          .ToList();
            this.UpdateColumns(games.Select(x => x.Name));
            var players =
                this.board.Players
                          .Except(e.RemovedPlayers)
                          .Concat(e.AddedPlayers)
                          .ToList();
            this.UpdateRows(players, games);
        }
        private void UpdateColumns(IEnumerable<string> columns)
        {
            this.Columns = new ObservableCollection<string>(columns);
            this.Columns.Insert(0, "Player");
            this.OnPropertyChanged("Columns");
        }
        private void UpdateRows(IEnumerable<Player> players, IEnumerable<Game> games)
        {
            var rows =
                from p in players
                let scores =
                    from g in games
                    select this.board.GetScore(p, g)
                let row = 
                    new RowViewModel
                    {
                        Player = p.Name,
                        Scores = new ObservableCollection<int>(scores)
                    }
                select row;
            this.Rows = new ObservableCollection<RowViewModel>(rows);
            this.OnPropertyChanged("Rows");
        }
    }
    public class RowViewModel
    {
        public string Player { get; set; }
        public ObservableCollection<int> Scores { get; set; }
    }
