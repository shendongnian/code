        #region SelectCardCommand
        public RelayCommand<Card> SelectCardCommand { get; private set; }
        #endregion
        public MainViewModel()
        {
            SelectCardCommand = new RelayCommand<Card>((s) => DoSelectCardCommand(s));
            GameBoard = new Board();
            this.StartGame();
        }
        private void DoSelectCardCommand(Card card)
        {
            if (card != null)
                card.Upside = true;
        }
