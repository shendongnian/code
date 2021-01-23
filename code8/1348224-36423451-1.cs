    private ObservableCollection<CurrentQuestions> questions = new ObservableCollection<CurrentQuestions>();
    
    public MainPage()
    {
        this.InitializeComponent();
        listView.ItemsSource = questions;
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        questions.Clear();
        foreach (var questionVm in questionnaireVm.CurrentQuestions)
        {
            //Add your data here
        }
    }
