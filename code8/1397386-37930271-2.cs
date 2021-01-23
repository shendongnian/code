    public DummyData TestData { get; set; }
    public MainWindow()
    {
        TestData = new DummyData() { Text = "This is a test data." };
        InitializeComponent();
    }
    public class DummyData
    {
        public string Text { get; set; }
        public string FirstThreeLetters
        {
            get
            {
                string result = string.Empty;
                if (!String.IsNullOrEmpty(Text))
                {
                    result = Text.Substring(0, 3);
                }
                return result;
            }
        }
        public string RestOfTheText
        {
            get
            {
                string result = string.Empty;
                if (!String.IsNullOrEmpty(Text))
                {
                    result = Text.Substring(3);
                }
                return result;
            }
        }
    }
    
