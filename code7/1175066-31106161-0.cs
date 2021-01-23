    public sealed partial class MainPage : Page
    {
        public class Quiz
        {
            public Question Question { get; set; }
        }
        public MainPage()
        {
            this.InitializeComponent();
            var options = new List<Option>();
            options.Add(new Option { name = "foo", value = "bar" });
            options.Add(new Option { name = "foo", value = "bar" });
            options.Add(new Option { name = "foo", value = "bar" });
            options.Add(new Option { name = "foo", value = "bar" });
            var question = new Question
            {
                Text = "Question 1",
                Options = new ObservableCollection<Option>(options)
            };
            this.DataContext = new Quiz { Question = question };
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
    }
    public class Question
    {
        public string Text { get; set; }
        public ObservableCollection<Option> Options { get; set; }
    }
    public class Option
    {
        public string name { get; set; }
        public string value { get; set; }
    }
