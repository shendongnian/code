    public partial class Form2 : Form
    {
        public string Category { get; set; }  // Property for selected category
    
        public Form2()  // Default constructor
        {
            InitializeComponent();
        }
    
        public Form2(string category) // Contructor with string parameter
        {
            Category = category;
            InitializeComponent();
            BindCategory();
            cmbCategory.SelectedItem = category;
        }
        private BindCategory()
        {
            // Your ComboBox binding logic.
        }
    }
