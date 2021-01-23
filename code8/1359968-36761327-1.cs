    public class ApplicationVm : ViewModelBase
    {
        public ApplicationVm()
        {
            RestartGameCommand = new RelayCommand(() => Game = new GameVm());
            RestartGameCommand.Execute(null);
        }
        public GameVm Game
        {
            get { return game; }
            private set
            {
                if (game != value)
                {
                    game = value;
                    OnPropertyChanged();
                }
            }
        }
        private GameVm game;
        public ICommand RestartGameCommand { get; set; }
    }
