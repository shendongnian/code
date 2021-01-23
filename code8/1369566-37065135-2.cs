    public NewMazeGrid()
    {
        myMaze = new MazePresentation();
        InitializeComponent();
        lst.ItemsSource = myMaze.MazePuzzleLists;
    }
