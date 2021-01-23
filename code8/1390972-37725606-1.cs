    public sealed partial class MainPage : Page
    {
        //Your intial string
        string words = "I am Line 1; I am Line 2; I am Line 3";
        //Using an ObservableCollection as works well with data binding
        public ObservableCollection<string> listOfWords { get; set; } = 
            new ObservableCollection<string>();
        public MainPage()
        {
            this.InitializeComponent();
            //set the DataContext to this page
            this.DataContext = this;
            Loaded += (s, args) =>
            {
                var splitWords = words.Split(';');
                foreach(var word in splitWords)
                {
                    //each line is added to listOfWords and can then be accessed by the ItemsControl as the ItemsSource
                    //is set to listOfWords
                    listOfWords.Add(word);
                }                
            };
        }
    }
