        public partial class Form2 : Form
        {
            private string json = "";
    
            public Form2(string jsonPassedId)
            {
                json = jsonPassedId;
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                // Use json here or in the constructor as required. 
            }
        }
    }
