    public BoardViewModel(...)
    {
         ...
         Columns = new ObservableCollection<BoardColumnViewModel>(Board.Columns.Select(c => new BoardColumnViewModel(c)));
    }
