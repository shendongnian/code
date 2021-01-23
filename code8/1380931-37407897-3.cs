        public partial class Form2 : Form
        {
            private string json = "";
            private string jsonUrl = "";
    
            public Form2(string jsonPassedId, string jsonUrlPassedIn)
            {
                json = jsonPassedId;
                jsonUrl = jsonUrlPassedIn;
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                // Use json and json URL here or in the constructor as required. 
            }
        }
    }
