    List<MatrixElement> _board;
    public MainWindow()
    {
        InitializeComponent();
        int rows = 10;
        int columns = 10;
        _board = new List<MatrixElement>();
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
                _board.Add(new MatrixElement(r, c){Color = "Green"});
        Board.ItemsSource = _board;
    }
    private void CellClick(object sender, MouseButtonEventArgs e)
    {
        var border = (Border)sender;
        // each point has unique {X;Y} coordinates
        var point = (MatrixElement)border.Tag;
        // changing color in item view model
        // view is notified by binding
        point.Color = "#00BFFF";
    }
