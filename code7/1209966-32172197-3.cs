    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            var board = new ScoreBoard();
            this.DataContext = new ViewModel(board);
        }
    }
