    public sealed partial class MainPage : Page
    {
        private string name = string.Empty;
        private string age = string.Empty;
        private string dinner = string.Empty;
        public MainPage()
        {
            this.InitializeComponent();
    
            name = tbxName.Text;
            age = tbxAge.Text;
            dinner = tbxDinner.Text;
    
            OutputNewValues();
        }
    
        private void OutputNewValues()
        {
            string answer = "Hello, " + name + " you are " + age + " years old. " + dinner + " sounds yummy for dinner!";
            finalOutput.Text = answer;
        }
    }
