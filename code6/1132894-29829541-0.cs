    public sealed partial class DetailPage: Page
    {
        private string testString;
    
        public String TestString
        {
            get { return this.testString; }
        }
    
        public EWRODetailPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }    
    }
