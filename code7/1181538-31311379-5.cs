    public partial class Form2 : Form
    {
        public int Category { get; set; }  // Property for selected category (You need this only if you need the category outside Form2 constructor)
    
        public Form2()  // Default constructor
        {
            InitializeComponent();
        }
    
        public Form2(int category) // Contructor with string parameter
        {
            Category = category;
            InitializeComponent();
            cmbCategory.Text = Category.ToString();  **// Use Text property instead of SelectedItem.**
        }
    }
