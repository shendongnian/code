    private readonly List<string> _questions;
    private int currentIndex = -1;
    public MainWindow()
    {
        InitializeComponent();
        _questions = GetQuestionsByDataReader();
    }
    private void btContinue_Click(object sender, RoutedEventArgs e)
    {
        if(currentIndex < _questions.Count)
        {
            lbquestion.Content = _questions[++currentIndex];
        }
    }
